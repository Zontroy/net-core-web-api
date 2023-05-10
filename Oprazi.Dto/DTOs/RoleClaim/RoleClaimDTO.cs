using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Oprazi.Dto.DTOs
{
    public class RoleClaimDTO : IdentityRoleClaim<int>
    {
    }
}

