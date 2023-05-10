using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class RoleClaimToListDTO
    {
        
        public Int32 Id { get; set; }
        
        public String RoleId { get; set; }
        
        public String ClaimType { get; set; }
        
        public String ClaimValue { get; set; }
        
    
        
        public string RoleName { get; set; }
        
    }
}

