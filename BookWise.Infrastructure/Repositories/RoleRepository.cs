using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookWise.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<List<string>> GetRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetUserRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.ToList();
            }
            return new List<string>();
        }
    }
}
