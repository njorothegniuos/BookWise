using Application.Abstractions.Messaging;
using BookWise.Domain.Abstractions;
using BookWise.Domain.Common;

namespace BookWise.Application.BookOrder.Commands
{
    internal class CreateBookOrderCommandHandler : ICommandHandler<CreateBookOrderCommand, Guid>
    {
        private readonly IBookOrderRepository _bookOrderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookOrderCommandHandler(IBookOrderRepository bookOrderRepository, IBookRepository bookRepository,
            IUnitOfWork unitOfWork)
        {
            _bookOrderRepository = bookOrderRepository;
            _bookRepository= bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateBookOrderCommand request, CancellationToken cancellationToken)
        {
            var _bookOrder = new Domain.Entities.BookModule.BookOrder(Guid.NewGuid(), request.BookId, request.UserId,
                request.ReserveDate, request.BorrowedDate, request.ReturnDate,
            request.RecordStatus);

            //ToDo: Handle book validation

            //ToDo: Handle user validation

            _bookOrderRepository.Insert(_bookOrder);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _bookOrder.Id;
        }
    }
}
