using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserLoginToResponseDTO : ResponseModelDTO
    {
        public List<UserLoginToListDTO> Data { get; set; } 

    }
}
