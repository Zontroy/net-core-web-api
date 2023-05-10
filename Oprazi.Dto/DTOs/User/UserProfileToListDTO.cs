using System;
using System.Collections.Generic;
using System.Text;

namespace Oprazi.Dto.DTOs
{
    public class UserProfileToListDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }        
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Menus { get; set; }
        public List<string> Claims { get; set; }
        public int? InstitutionId { get; set; }
        public int? SubinstitutionId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PersonId { get; set; }
        public string Pic { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public string Website { get; set; }



    }
}

