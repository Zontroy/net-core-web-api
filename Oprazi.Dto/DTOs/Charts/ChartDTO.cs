using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dto.DTOs
{
    public class ChartDTO
    {
        public List<int> Series1 { get; set; }
        public List<int> Series2 { get; set; }
        public List<string> Categories { get; set; }
    }
}
