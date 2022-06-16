using ProjectEmployee_Intership.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetProjectRequest
    {
        public string ?ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string ?FirstName { get; set; }
        public string ?OrderBy { get; set; }
    }
}
