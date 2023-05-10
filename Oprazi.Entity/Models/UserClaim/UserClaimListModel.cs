using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserClaimListModel
    {
        
        public Int32 Id { get; set; }
        
        public Int32 UserId { get; set; }
        
        public String ClaimType { get; set; }
        
        public String ClaimValue { get; set; }
        
    
        
        public string UserName { get; set; }
        

    }
}
