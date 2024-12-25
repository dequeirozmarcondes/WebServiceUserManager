using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebServiceUserManager.Models;

namespace WebServiceUserManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Personalização do modelo do Identity
            // Por exemplo, renomear os nomes das tabelas do Identity
            builder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "Users"); });
            builder.Entity<IdentityRole<Guid>>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<Guid>>(entity => { entity.ToTable("UserRoles"); });
            builder.Entity<IdentityUserClaim<Guid>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<Guid>>(entity => { entity.ToTable("UserLogins"); });
            builder.Entity<IdentityRoleClaim<Guid>>(entity => { entity.ToTable("RoleClaims"); });
            builder.Entity<IdentityUserToken<Guid>>(entity => { entity.ToTable("UserTokens"); });
        }
    }
}