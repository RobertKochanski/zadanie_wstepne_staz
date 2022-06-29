using stazServices.RestModels;
using stazServices.ViewModels;

namespace stazServices.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookWithAuthorViewModel> GetBook(Guid id);

        Task<List<BookViewModel>> GetBooks();

        Task AddBook(AddBookRequest request);

        Task RemoveBook(Guid id);

        Task UpdateBook(Guid id, UpdateBookRequest request);
    }
}
