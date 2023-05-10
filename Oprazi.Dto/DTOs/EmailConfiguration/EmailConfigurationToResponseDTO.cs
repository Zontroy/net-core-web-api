using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprazi.Dto.DTOs
{
    public class EmailConfigurationToResponseDTO : ResponseModelDTO
    {
        public List<EmailConfigurationToListDTO> Data { get; set; }

    }
}
