﻿using ProjectEmployee_Intership.Core.Models.Dto;
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
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DeadLine { get; set; }
        public int ? PageNumber { get; set; }
        public int ? PageSize { get; set; }
        public int EmployeeId { get; set; }
        public string ? Sort { get; set; }
    }
}
