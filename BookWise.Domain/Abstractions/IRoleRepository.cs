namespace BookWise.Domain.Abstractions
{
    public interface IRoleRepository
    {
        Task<List<string>> GetRole(string roleId);
    }
}
