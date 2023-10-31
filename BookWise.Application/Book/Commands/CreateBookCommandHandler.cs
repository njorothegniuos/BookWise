using Application.Abstractions.Messaging;
using BookWise.Domain.Abstractions;
using BookWise.Domain.Common;

namespace BookWise.Application.Book.Commands
{
    internal class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var _book = new Domain.Entities.BookModule.Book( Guid.NewGuid(), request.Title, request.Author, request.ISBN, request.PublicationDate,
            RecordStatus.Available);

            _bookRepository.Insert(_book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _book.Id;
        }
    }
}
