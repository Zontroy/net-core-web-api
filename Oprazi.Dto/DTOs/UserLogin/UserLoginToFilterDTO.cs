using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserLoginToFilterDTO : BaseFilterDTO
    {
        
        
        public String ProviderDisplayName { get; set; }
        
        public String UserId { get; set; }
        
        
    }
}
