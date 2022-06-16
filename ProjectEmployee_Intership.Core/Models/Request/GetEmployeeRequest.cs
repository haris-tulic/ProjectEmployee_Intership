using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Database;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetEmployeeRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
     }
}
