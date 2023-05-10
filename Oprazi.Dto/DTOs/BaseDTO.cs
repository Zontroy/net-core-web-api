using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
    }
}
