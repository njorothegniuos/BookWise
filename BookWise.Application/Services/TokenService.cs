using BookWise.Application.User.Queries.Login;
using BookWise.Domain.Abstractions;
using BookWise.Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookWise.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        public TokenService(IConfiguration configuration, IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository)
        {
            _configuration = configuration;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }
        public async Task<TokenResponse> BuildToken(string userId)
        {
            //security key for token validation
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Security:Key"]));

            //credentials for signing token
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime baseDate = DateTime.UtcNow;

            DateTime expiryDate = baseDate.AddMinutes(Convert.ToInt32(_configuration["Security:TokenLifetimeInMins"]));

            Guid jti = Guid.NewGuid();

            //GET ROLES 
            var _roles = await _userRoleRepository.GetUserRole(userId);
            List<Claim> claims = new List<Claim>();
            foreach (var role in _roles)
            {
                //add claims
                claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Jti, $"{jti}"),
                new Claim("cli", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, role),
                };
            }


            //create token
            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: _configuration["Security:Issuer"],
                audience: _configuration["Security:Audience"],
                signingCredentials: signingCredentials,
                expires: expiryDate,
                notBefore: baseDate,
                claims: claims);

            string generatedToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            TokenResponse tokenResponse = new TokenResponse(generatedToken, expiryDate.ToEpoch(), "Bearer");
            return tokenResponse;
        }
    }
}
