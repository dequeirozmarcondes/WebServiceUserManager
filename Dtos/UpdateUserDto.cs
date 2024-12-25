namespace WebServiceUserManager.Dtos
{
    public class UpdateUserDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
