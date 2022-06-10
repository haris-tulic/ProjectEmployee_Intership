﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEmployee_Intership.Database;

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
