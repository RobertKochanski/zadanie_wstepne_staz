using stazDAL.Entities;

namespace stazDAL.Repositories.Interfaces
{
    public interface IBookRepositorie
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<List<Book>> GetAsync();
        Task AddAsync(Book book);
        Task RemoveAsync(Book book);
        Task SaveChangesAsync();
    }
}
