using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookWise.Application.User.Queries.Login
{
    public sealed record GetUserByUserNameQuery(string Email, string Password) : IQuery<Results<Ok<TokenResponse>, BadRequest<string>>>;
}
