using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserClaimToResponseDTO : ResponseModelDTO
    {
        public List<UserClaimToListDTO> Data { get; set; } 

    }
}
