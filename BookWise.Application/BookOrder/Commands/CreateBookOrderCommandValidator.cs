using FluentValidation;

namespace BookWise.Application.BookOrder.Commands
{
    public sealed class CreateBookOrderCommandValidator : AbstractValidator<CreateBookOrderCommand>
    {
        public CreateBookOrderCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();

            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
