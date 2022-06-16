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
        public StatusProject Status { get; set; }
        public string FirstName { get; set; }
        const int maxSize = 3;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 2;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxSize) ? maxSize : value; }
        }
        public string OrderBy { get; set; }
        public string Sort { get; set; }
    }
}
