using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class AuthModel
    {
        
        public string api_token { get; set; }
        
        public string refreshToken { get; set; }
        public string currentRole { get; set; }
        
    }
}
