namespace WebServiceUserManager.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userName, string userEmail, Guid userId);
    }
}
