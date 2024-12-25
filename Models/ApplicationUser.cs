using Microsoft.AspNetCore.Identity;

namespace WebServiceUserManager.Models
{
    // Classe de usuário personalizada que herda de IdentityUser<Guid>
    public class ApplicationUser : IdentityUser<Guid>
    {
        // Add custom properties here
    }
}
