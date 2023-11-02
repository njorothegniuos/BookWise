using Application.Abstractions.Messaging;
using BookWise.Domain.Abstractions;
using Mapster;

namespace BookWise.Application.UserRole.Queries
{
    internal class GetUserRoleByUserIdQueryHandler : IQueryHandler<GetUserRoleByUserIdQuery, UserRoleResponse>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public GetUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRoleResponse> Handle(
            GetUserRoleByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRoleRepository.GetUserRole(request.UserId);
            var userResponse = user.Adapt<UserRoleResponse>();
            return userResponse;
        }
    }
}
