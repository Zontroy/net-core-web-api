using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserResponseModel : ResponseModel
    {
        public List<UserListModel> Data { get; set; } 

    }
}
