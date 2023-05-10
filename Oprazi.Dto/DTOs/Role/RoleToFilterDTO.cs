using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class RoleToFilterDTO : BaseFilterDTO
    {
        
        
        public String Name { get; set; }
        
        public String NormalizedName { get; set; }
        
        public String ConcurrencyStamp { get; set; }
        
        
    }
}
