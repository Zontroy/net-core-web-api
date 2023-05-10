using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Entity.Models
{
    public class ChartDecimalModel
    {
        public List<decimal> Series1 { get; set; }
        public List<decimal> Series2 { get; set; }
        public List<string> Categories { get; set; }
    }
}
