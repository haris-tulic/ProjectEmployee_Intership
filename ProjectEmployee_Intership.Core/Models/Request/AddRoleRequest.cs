using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class AddRoleRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
