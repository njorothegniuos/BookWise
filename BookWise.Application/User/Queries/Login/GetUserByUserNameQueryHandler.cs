using Application.Abstractions.Messaging;
using BookWise.Application.Services;
using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace BookWise.Application.User.Queries.Login
{
    internal class GetUserByUserNameQueryHandler : IQueryHandler<GetUserByUserNameQuery, Results<Ok<TokenResponse>, BadRequest<string>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public GetUserByUserNameQueryHandler(IUserRepository userRepository, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Results<Ok<TokenResponse>, BadRequest<string>>> Handle(
            GetUserByUserNameQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var signInStatus = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

                if (signInStatus.Succeeded)
                {
                    return TypedResults.Ok(_tokenService.BuildToken());
                }
                else { return TypedResults.BadRequest("Invalid credentials"); }
            }

            return TypedResults.BadRequest("Invalid credentials");
        }
    }
}
