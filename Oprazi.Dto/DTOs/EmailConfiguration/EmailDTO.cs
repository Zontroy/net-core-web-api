using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dto.DTOs
{
    public class EmailDTO : BaseDTO
    {

        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
    }
}
