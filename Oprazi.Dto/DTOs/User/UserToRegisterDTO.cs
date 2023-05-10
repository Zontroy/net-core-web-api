using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Oprazi.Dto.DTOs
{
    public class UserToRegisterDTO : IdentityUser<int>
    {
        public string Password { get; set; }
        public string InstitutionName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public int LanguageId { get; set; }
        public int SubinstitutionTypeId { get; set; }

    }
}
