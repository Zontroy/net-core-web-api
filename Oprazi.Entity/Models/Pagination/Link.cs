using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class Link
    {
        public String Url { get; set; }
        public String Label { get; set; }
        public bool Active{ get; set; }
        public int? Page { get; set; }        

    }
}
