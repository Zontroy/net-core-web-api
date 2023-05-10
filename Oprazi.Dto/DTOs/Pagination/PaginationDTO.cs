using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; }
        public String First_Page_Url { get; set; }
        public int From { get; set; }
        public int Last_Page { get; set; }
        public List<LinkDTO> Links { get; set; }
        public String Next_Page_Url { get; set; }
        public int Items_Per_Page { get; set; }
        public String Prev_Page_Url { get; set; }
        public int To { get; set; }
        public int Total { get; set; }

    }
}
