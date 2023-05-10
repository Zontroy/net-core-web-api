using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class RoleClaimToFilterDTO : BaseFilterDTO
    {
        
        
        public String RoleId { get; set; }
        
        public String ClaimType { get; set; }
        
        public String ClaimValue { get; set; }
        
        
    }
}
