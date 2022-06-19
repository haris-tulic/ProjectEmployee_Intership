namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class GetProjectRequest
    {
        public string? ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string? FirstName { get; set; }
        public string? OrderBy { get; set; }

    }
}
