using Microsoft.AspNetCore.Identity;

namespace BookWise.Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        public byte RoleType { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }
    }
}
