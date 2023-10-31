using Application.Abstractions.Messaging;
using BookWise.Application.User.Queries.GetUserByEmail;
using BookWise.Domain.Abstractions;
using Mapster;

namespace BookWise.Application.Book.Queries
{
    internal class SearchForABookQueryHandler : IQueryHandler<SearchForABookQuery, BookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public SearchForABookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> Handle(
            SearchForABookQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _bookRepository.SearchForABook(request.Value);
            var userResponse = user.Adapt<BookResponse>();
            return userResponse;
        }
    }
}
