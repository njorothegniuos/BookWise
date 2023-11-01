using Application.Abstractions.Messaging;
using BookWise.Domain.Abstractions;
using Mapster;

namespace BookWise.Application.Book.Queries
{
    internal class SearchForABookQueryHandler : IQueryHandler<SearchForABookQuery, BooksResponse>
    {
        private readonly IBookRepository _bookRepository;

        public SearchForABookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BooksResponse> Handle(
           SearchForABookQuery request,
           CancellationToken cancellationToken)
        {
            var book = await _bookRepository.SearchForABook(request.Value);
            var bookresponse = book.Adapt<BooksResponse>();
            return bookresponse;
        }
    }
}
