using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserTokenResponseModel : ResponseModel
    {
        public List<UserTokenListModel> Data { get; set; } 

    }
}
