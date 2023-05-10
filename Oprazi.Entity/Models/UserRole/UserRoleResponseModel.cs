using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserRoleResponseModel : ResponseModel
    {
        public List<UserRoleListModel> Data { get; set; } 

    }
}
