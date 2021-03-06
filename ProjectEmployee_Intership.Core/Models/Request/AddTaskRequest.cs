namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class AddTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime DeadLine { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? EmployeeId { get; set; }
    }
}
