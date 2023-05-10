using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dto.DTOs
{
    public class FileDTO
    {
        public byte[] Data { get; set; }
        public string MimeType { get; set;  }
        public string Name { get; set; }
    }

    public class FileTextDTO
    {
        public string Data { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
    }
}
