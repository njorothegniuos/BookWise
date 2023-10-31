using BookWise.Application.Dto;
using BookWise.Application.User.Queries.Login;

namespace BookWise.Application.Services
{
    public interface ITokenService
    {
        TokenResponse BuildToken();
    }
}
