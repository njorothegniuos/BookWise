using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure
{
    public class IdentityDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IUnitOfWork
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>();
            modelBuilder.Entity<ApplicationRole>();

            modelBuilder.Entity<ApplicationUserRole>();
            modelBuilder.Entity<IdentityUserClaim<string>>();
            modelBuilder.Entity<IdentityUserLogin<string>>();
            modelBuilder.Entity<IdentityRoleClaim<string>>();
            modelBuilder.Entity<IdentityUserToken<string>>();
        }
    }
}
