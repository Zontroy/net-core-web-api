using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class RoleClaimListModel
    {
        
        public Int32 Id { get; set; }
        
        public Int32 RoleId { get; set; }
        
        public String ClaimType { get; set; }
        
        public String ClaimValue { get; set; }
        
    
        
        public string RoleName { get; set; }
        

    }
}
