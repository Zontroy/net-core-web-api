using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class BaseFilterModel
    {
        public int? Page { get; set; }
        public int? Items_Per_Page { get; set; }
        public string Search { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
