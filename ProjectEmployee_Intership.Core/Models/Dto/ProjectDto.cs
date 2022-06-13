using ProjectEmployee_Intership.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusProject Status { get; set; }
        public bool IsDeleted { get; set; }
        public List<EmployeeDto> Employees { get; set; }
        public List<TasksDto> Tasks { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
