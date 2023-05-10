using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class RoleClaimToResponseDTO : ResponseModelDTO
    {
        public List<RoleClaimToListDTO> Data { get; set; } 

    }
}
