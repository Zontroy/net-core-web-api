using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class BaseFilterDTO
    {
        public int? Page { get; set; }
        public int? Items_Per_Page { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
