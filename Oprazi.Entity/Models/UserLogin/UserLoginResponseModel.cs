using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserLoginResponseModel : ResponseModel
    {
        public List<UserLoginListModel> Data { get; set; } 

    }
}
