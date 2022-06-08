using ProjectEmployee_Intership.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectDto Project { get; set; }
        public UserDto User { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
