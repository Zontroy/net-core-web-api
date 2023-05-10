using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserClaimFilterModel : BaseFilterModel
    {
        
        
        public String UserId { get; set; }
        
        public String ClaimType { get; set; }
        
        public String ClaimValue { get; set; }
        
        
    
        

    }
}
