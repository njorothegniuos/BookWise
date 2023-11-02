using BookWise.Application.User.Queries.Login;

namespace BookWise.Application.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> BuildToken(string userId);
    }
}
