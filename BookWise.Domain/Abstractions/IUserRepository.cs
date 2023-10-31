using BookWise.Domain.Entities.Identity;

namespace BookWise.Domain.Abstractions
{
    public  interface IUserRepository
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
    }
}
