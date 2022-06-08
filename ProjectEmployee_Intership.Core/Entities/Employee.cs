using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProjectEmployee> Projects { get; set; }
        public List<Tasks> Tasks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
