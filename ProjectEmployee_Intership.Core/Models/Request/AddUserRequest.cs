namespace ProjectEmployee_Intership.Core.Models.Request
{
    public class AddUserRequest
    {
        public int RoleId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
