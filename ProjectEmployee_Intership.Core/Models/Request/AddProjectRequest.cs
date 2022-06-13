using ProjectEmployee_Intership.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class AddProjectRequest
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public StatusProject Status { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
    }
}
