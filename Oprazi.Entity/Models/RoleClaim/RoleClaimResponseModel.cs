using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class RoleClaimResponseModel : ResponseModel
    {
        public List<RoleClaimListModel> Data { get; set; } 

    }
}
