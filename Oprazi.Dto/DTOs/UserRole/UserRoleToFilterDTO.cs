using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserRoleToFilterDTO : BaseFilterDTO
    {
        public Nullable<Int32> SubinstitutionId { get; set; }

        public Nullable<Int32> InstitutionId { get; set; }
        public Nullable<Int32> RoleId { get; set; }
        public Nullable<Int32> UserId { get; set; }
    }
}
