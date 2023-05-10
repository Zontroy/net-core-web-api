using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dto.DTOs.Error
{
    public class ErrorResponseDTO
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

    }
}
