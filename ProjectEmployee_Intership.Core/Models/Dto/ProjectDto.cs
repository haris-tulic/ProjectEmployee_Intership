using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEmployee_Intership.Common.Enums;

namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusProject Status { get; set; }
        public List<ProjectEmployeeDto> Employees { get; set; }
        public List<TasksDto> Tasks { get; set; }
    }
}
