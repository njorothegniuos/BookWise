using BookWise.Api.Contracts.User;
using BookWise.Application.User.Queries.GetUserByEmail;
using BookWise.Application.User.Queries.Login;
using Carter;
using MediatR;

namespace BookWise.Api.Controllers
{
    public class AuthEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/auth");

            group.MapPost("", FindByEmailAsync);
            group.MapPost("/login", TokenAsync);
        }
        public static async Task<IResult> FindByEmailAsync(string email, 
            ISender sender, CancellationToken cancellationToken)
        {
            var query = new GetUserByEmailQuery(email);
            var response = await sender.Send(query, cancellationToken);
            return Results.Ok(response);
        }

        public static async Task<IResult> TokenAsync(UserModel userModel, 
            ISender sender, CancellationToken cancellationToken)
        {
            var query = new GetUserByUserNameQuery(userModel.Email, userModel.Password);
            return await sender.Send(query, cancellationToken);
        }
    }
}
