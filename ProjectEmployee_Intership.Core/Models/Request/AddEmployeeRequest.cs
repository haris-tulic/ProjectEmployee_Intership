namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class AddEmployeeRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }

    }
}
