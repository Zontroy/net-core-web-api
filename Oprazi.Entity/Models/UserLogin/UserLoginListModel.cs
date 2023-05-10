using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserLoginListModel
    {
        
        public String LoginProvider { get; set; }
        
        public String ProviderKey { get; set; }
        
        public String ProviderDisplayName { get; set; }
        
        public Int32 UserId { get; set; }
        
    
        
        public string UserName { get; set; }
        

    }
}
