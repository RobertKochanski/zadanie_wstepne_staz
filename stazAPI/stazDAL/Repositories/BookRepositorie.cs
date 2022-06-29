using Microsoft.EntityFrameworkCore;
using stazDAL.Entities;
using stazDAL.Repositories.Interfaces;

namespace stazDAL.Repositories
{
    public class BookRepositorie : IBookRepositorie
    {
        private readonly StazDbContext _context;

        public BookRepositorie(StazDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Book book)
        {
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAsync()
        {
            return await _context.books
                .Include(a => a.Author)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.books
                .Include(a => a.Author)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
