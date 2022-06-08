using ProjectEmployee_Intership.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetUserRequest
    {
        public RoleDto Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
    }
}
