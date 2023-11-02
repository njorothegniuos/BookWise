namespace BookWise.Domain.Abstractions
{
    public interface IUserRoleRepository
    {
        Task<List<string>> GetUserRole(string userId);
    }
}
