using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Entity.Models
{
    public class UserFilterModel : BaseFilterModel
    {

        public String UserName { get; set; }

        public String Email { get; set; }

        public String PhoneNumber { get; set; }

        public Nullable<Int32> SubinstitutionId { get; set; }

        public Nullable<Int32> InstitutionId { get; set; }



    }
}
