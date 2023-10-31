using Microsoft.AspNetCore.Identity;

namespace BookWise.Domain.Entities.Identity
{
    public class ApplicationUserRole : IdentityRole<string>
    {
        public ApplicationUserRole() : base()
        {
        }
      public virtual ApplicationRole Role { get; set; }
    }
}
