namespace ProjectEmployee_Intership.Core.Models.Dto
{
    public class TasksDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
        public int EmployeeId { get; set; }
        public UserDto Employee { get; set; }
        public bool IsFinished { get; set; } 
        public DateTime DeadLine { get; set; }
    }
}
