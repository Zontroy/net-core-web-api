using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserTokenToResponseDTO : ResponseModelDTO
    {
        public List<UserTokenToListDTO> Data { get; set; } 

    }
}
