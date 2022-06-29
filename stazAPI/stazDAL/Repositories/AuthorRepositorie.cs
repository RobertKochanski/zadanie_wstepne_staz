using Microsoft.EntityFrameworkCore;
using stazDAL.Entities;
using stazDAL.Repositories.Interfaces;

namespace stazDAL.Repositories
{
    public class AuthorRepositorie : IAuthorRepositorie
    {
        private readonly StazDbContext _context;

        public AuthorRepositorie(StazDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author author)
        {
            await _context.authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _context.authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAsync()
        {
            return await _context.authors
                .Include(b => b.Books)
                .ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _context.authors
                .Include(b => b.Books)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
