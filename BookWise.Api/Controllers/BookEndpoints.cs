using BookWise.Api.Contracts.BookModule;
using BookWise.Application.Book.Commands;
using BookWise.Application.Book.Queries;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BookWise.Api.Controllers
{
    public class BookEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/book");

            group.MapPost("", CreateBook);
            group.MapPost("/search", SearchForABookAsync);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "SuperAdministrator")]
        public static async Task<IResult> CreateBook(BookRequest request,
            ISender sender, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateBookCommand>();
            var response = await sender.Send(command, cancellationToken);
            return Results.Ok(response);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdministrator,StandardUser")]
        public static async Task<IResult> SearchForABookAsync(string filter,
            ISender sender, CancellationToken cancellationToken)
        {
            var query = new SearchForABookQuery(filter);
            var response = await sender.Send(query, cancellationToken);
            return Results.Ok(response);
        }
    }
}
