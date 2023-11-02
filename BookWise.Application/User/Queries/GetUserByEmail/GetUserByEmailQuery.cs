using Application.Abstractions.Messaging;

namespace BookWise.Application.User.Queries.GetUserByEmail
{
    public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
}
