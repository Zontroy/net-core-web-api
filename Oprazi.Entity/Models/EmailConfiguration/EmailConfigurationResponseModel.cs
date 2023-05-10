using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class EmailConfigurationResponseModel : ResponseModel
    {
        public List<EmailConfigurationListModel> Data { get; set; } 

    }
}
