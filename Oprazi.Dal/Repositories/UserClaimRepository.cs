using Oprazi.Dal.DataContext;
using Oprazi.Dal.Repositories.IRepositories;
using Oprazi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Oprazi.Entity.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oprazi.Dal.Repositories
{
    public class UserClaimRepository : GenericRepository<UserClaim>, IUserClaimRepository
    {
        private readonly AspNetCoreNTierDbContext _aspNetCoreNTierDbContext;
        public UserClaimRepository(AspNetCoreNTierDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
        {
            _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
        }

        public async Task<UserClaimResponseModel> GetUserClaimList(UserClaimFilterModel filter)
        {
            var UserClaims = (from userclaim in _aspNetCoreNTierDbContext.UserClaims

                              join user in _aspNetCoreNTierDbContext.Users on userclaim.UserId equals user.Id

                              where
                               (
                                      (filter.Search == null || userclaim.ClaimType.Contains(filter.Search))

                                      || (filter.Search == null || userclaim.ClaimValue.Contains(filter.Search))

                               )

                              select new UserClaimListModel
                              {
                                  Id = userclaim.Id,

                                  UserId = userclaim.UserId,

                                  ClaimType = userclaim.ClaimType,

                                  ClaimValue = userclaim.ClaimValue,

                                  UserName = user.UserName,

                              }).FilteredOrderBy(filter.Sort, filter.Order == "asc");

            var response = new UserClaimResponseModel();
            response.Data = UserClaims.Skip(filter.Page != null && filter.Items_Per_Page != null ? (Convert.ToInt32(filter.Page) - 1) * Convert.ToInt32(filter.Items_Per_Page) : 0)
                    .Take(filter.Items_Per_Page != null ? Convert.ToInt32(filter.Items_Per_Page) : 100)
                    .ToList(); ;
            response.Payload = new Payload();
            response.Payload.Pagination = new Pagination();
            if (filter.Page != null)
                response.Payload.Pagination.Page = Convert.ToInt32(filter.Page);
            response.Payload.Pagination.First_Page_Url = "/?page=1";
            response.Payload.Pagination.From = 1;
            if (filter.Items_Per_Page != null)
                response.Payload.Pagination.Last_Page = Convert.ToInt32(Math.Ceiling(UserClaims.Count() / Convert.ToDecimal(filter.Items_Per_Page)));

            response.Payload.Pagination.Links = new List<Link>();

            int paginationBeginPage = 0;
            if (filter.Page != null)
                paginationBeginPage = (Convert.ToInt32(filter.Page) - 1) / 10 * 10;

            int paginationEndPage = (paginationBeginPage + 10);
            if (response.Payload.Pagination.Last_Page < paginationEndPage)
                paginationEndPage = response.Payload.Pagination.Last_Page;

            response.Payload.Pagination.Links.Add(new Link
            {
                Url = "/?page=" + (paginationBeginPage == 0 ? null : (paginationBeginPage - 10 + 1)),
                Label = "&laquo; Previous",
                Active = false,
                Page = (paginationBeginPage == 0 ? null : (paginationBeginPage - 10 + 1))
            });

            for (int i = paginationBeginPage; i < paginationEndPage; i++)
            {
                response.Payload.Pagination.Links.Add(new Link
                {
                    Url = "/?page=" + (i + 1),
                    Label = Convert.ToString(i + 1),
                    Active = Convert.ToInt32(filter.Page) == (i + 1),
                    Page = (i + 1)
                });
            }

            response.Payload.Pagination.Links.Add(new Link
            {
                Url = response.Payload.Pagination.Last_Page > (paginationBeginPage + 10) ? "/?page=" + (paginationBeginPage + 11) : null,
                Label = "Next &raquo;",
                Active = false,
                Page = response.Payload.Pagination.Last_Page > (paginationBeginPage + 10) ? (paginationBeginPage + 11) : null
            });

            if (filter.Page != null)
                response.Payload.Pagination.Next_Page_Url = "/?page=" + (Convert.ToInt32(filter.Page) + 1);
            if (filter.Items_Per_Page != null)
                response.Payload.Pagination.Items_Per_Page = Convert.ToInt32(filter.Items_Per_Page);
            if (filter.Page != null)
                response.Payload.Pagination.Prev_Page_Url = Convert.ToInt32(filter.Page) > 1 ? "/?page=" + (Convert.ToInt32(filter.Page) - 1) : null;
            response.Payload.Pagination.To = 10;
            response.Payload.Pagination.Total = UserClaims.Count();

            return response;
        }

        public async Task<UserClaim> GetUserClaimById(int Id)
        {
            return (from userclaim in _aspNetCoreNTierDbContext.UserClaims
                    where userclaim.Id == Id
                    select new UserClaim
                    {
                        Id = userclaim.Id,
                        UserId = userclaim.UserId,
                        ClaimType = userclaim.ClaimType,
                        ClaimValue = userclaim.ClaimValue
                    }).FirstOrDefault();
        }
    }
}
