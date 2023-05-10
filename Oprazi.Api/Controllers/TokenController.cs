using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oprazi.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oprazi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
                
        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        
    }
}
