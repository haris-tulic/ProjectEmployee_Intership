using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class AddEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int projectId { get; set; }
        public int taskId { get; set; }
       
        
    }
}
