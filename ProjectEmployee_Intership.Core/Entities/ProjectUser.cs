using System.ComponentModel.DataAnnotations;

namespace Intership_ProjectTeam4.Database
{
    public class ProjectUser
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
