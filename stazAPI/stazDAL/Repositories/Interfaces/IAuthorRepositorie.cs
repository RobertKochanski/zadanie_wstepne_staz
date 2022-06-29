using stazDAL.Entities;

namespace stazDAL.Repositories.Interfaces
{
    public interface IAuthorRepositorie
    {
        Task<Author> GetByIdAsync(Guid id);
        Task<List<Author>> GetAsync();
        Task AddAsync(Author author);
        Task DeleteAsync(Author author);
        Task SaveChangesAsync();
    }
}
