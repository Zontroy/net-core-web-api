using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class LinkDTO
    {
        public String Url { get; set; }
        public String Label { get; set; }
        public bool Active{ get; set; }
        public int? Page { get; set; }        

    }
}
