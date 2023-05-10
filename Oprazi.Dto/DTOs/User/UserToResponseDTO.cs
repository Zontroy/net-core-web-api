using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserToResponseDTO : ResponseModelDTO
    {
        public List<UserToListDTO> Data { get; set; } 

    }
}
