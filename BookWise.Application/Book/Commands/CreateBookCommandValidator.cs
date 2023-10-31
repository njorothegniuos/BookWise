using FluentValidation;

namespace BookWise.Application.Book.Commands
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.PublicationDate).NotEmpty();
        }
    }
}
