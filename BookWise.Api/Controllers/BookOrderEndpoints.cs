using BookWise.Api.Contracts.BookModule;
using BookWise.Application.BookOrder.Commands;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BookWise.Api.Controllers
{
    public class BookOrderEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/bookOrder");

            group.MapPost("", CreateBookOrderAsync);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdministrator")]
        public static async Task<IResult> CreateBookOrderAsync(BookOrderRequest request,
           ISender sender, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateBookOrderCommand>();
            var response = await sender.Send(command, cancellationToken);
            return Results.Ok(response);
        }
    }
}
