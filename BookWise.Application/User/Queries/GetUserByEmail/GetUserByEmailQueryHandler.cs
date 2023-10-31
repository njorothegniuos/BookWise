using Application.Abstractions.Messaging;
using BookWise.Domain.Abstractions;
using Mapster;
using System.Data;

namespace BookWise.Application.User.Queries.GetUserByEmail
{
    internal class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(
            GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            var userResponse = user.Adapt<UserResponse>();
            return userResponse;
        }
    }
}
