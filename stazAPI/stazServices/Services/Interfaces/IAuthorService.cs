using stazDAL.Entities;
using stazServices.RestModels;
using stazServices.ViewModels;

namespace stazServices.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorWithBooksViewModel> GetAuthor(Guid id);

        Task<List<AuthorViewModel>> GetAuthors();

        Task AddAuthor(AddAuthorRequest request);

        Task RemoveAuthor(Guid id);

        Task UpdateAuthor(Guid id, UpdateAuthorRequest author);
    }
}
