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
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public GetUserByUserNameQueryHandler(IUserRepository userRepository, SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userRoleRepository = userRoleRepository;
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
                    var token = await _tokenService.BuildToken(user.Id);
                    if (token != null)
                        return TypedResults.Ok(token);
                    else
                        return TypedResults.BadRequest("Invalid credentials");
                }
                else { return TypedResults.BadRequest("Invalid credentials"); }
            }

            return TypedResults.BadRequest("Invalid credentials");
        }
    }
}
