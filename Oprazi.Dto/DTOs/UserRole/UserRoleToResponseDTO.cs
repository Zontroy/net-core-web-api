using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserRoleToResponseDTO : ResponseModelDTO
    {
        public List<UserRoleToListDTO> Data { get; set; } 

    }
}
