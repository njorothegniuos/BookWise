using Application.Abstractions.Messaging;

namespace BookWise.Application.UserRole.Queries
{
    public sealed record GetUserRoleByUserIdQuery(string UserId) : IQuery<UserRoleResponse>;
}
