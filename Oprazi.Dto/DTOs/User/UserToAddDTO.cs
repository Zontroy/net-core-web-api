using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Oprazi.Dto.DTOs
{
    public class UserToAddDTO : IdentityUser<int>
    {
        public string Password { get; set; }
        
    }
}
