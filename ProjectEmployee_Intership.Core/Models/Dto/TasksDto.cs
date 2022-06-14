namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class TasksDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EmployeeDto> Employee { get; set; }
        public bool IsFinished { get; set; } 
        public DateTime DeadLine { get; set; }
        public List<UserDto> Users { get; set; }
        public bool IsDeleted { get; set; }
    }
}
