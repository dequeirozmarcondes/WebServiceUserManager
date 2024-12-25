namespace WebServiceUserManager.Services
{
    public interface ITokenService
    {
        // Assinatura do método para gerar token JWT
        Task<string> GenerateJwtToken(string userName, string userEmail, Guid userId);
    }
}
