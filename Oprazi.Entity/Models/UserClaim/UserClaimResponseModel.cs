using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserClaimResponseModel : ResponseModel
    {
        public List<UserClaimListModel> Data { get; set; } 

    }
}
