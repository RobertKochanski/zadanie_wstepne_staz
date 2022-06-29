using AutoMapper;
using stazAPI.Service;
using stazDAL.Entities;
using stazDAL.Repositories.Interfaces;
using stazServices.RestModels;
using stazServices.Services.Interfaces;
using stazServices.ViewModels;

namespace stazServices.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositorie _bookRepositorie;
        private readonly IAuthorRepositorie _authorRepositorie;
        private readonly IMapper _mapper;

        public BookService(IBookRepositorie bookRepositorie, IMapper mapper, IAuthorRepositorie authorRepositorie)
        {
            _bookRepositorie = bookRepositorie;
            _authorRepositorie = authorRepositorie;
            _mapper = mapper;
        }

        public async Task<BookWithAuthorViewModel> GetBook(Guid id)
        {
            var bookFromDb = await _bookRepositorie.GetByIdAsync(id);

            if (bookFromDb == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<BookWithAuthorViewModel>(bookFromDb);
        }

        public async Task<List<BookViewModel>> GetBooks()
        {
            var booksFromDb = await _bookRepositorie.GetAsync();
            return _mapper.Map<List<BookViewModel>>(booksFromDb);
        }

        public async Task AddBook(AddBookRequest request)
        {
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Title))
            {
                throw new BadRequestException("Nie podano wszystkich danych");
            }

            if (request.Release_Date > DateTime.Now)
            {
                throw new BadRequestException("Podano złą datę");
            }

            if (_authorRepositorie.GetByIdAsync(request.AuthorId) == null) 
            {
                throw new BadRequestException("Podany autor nie istnieje");
            }

            await _bookRepositorie.AddAsync(new Book()
            {
                Title = request.Title,
                Description = request.Description,
                Release_Date = request.Release_Date,
                AuthorId = request.AuthorId,
            });
        }

        public async Task RemoveBook(Guid id)
        {
            var bookFromDb = await _bookRepositorie.GetByIdAsync(id);

            if (bookFromDb == null)
            {
                throw new BadRequestException("Podana książka nie istnieje");
            }

            await _bookRepositorie.RemoveAsync(bookFromDb);
        }

        public async Task UpdateBook(Guid id, UpdateBookRequest request)
        {
            var bookFromDb = await _bookRepositorie.GetByIdAsync(id);

            if (bookFromDb == null)
            {
                throw new BadRequestException("Podana książka nie istnieje");
            }

            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Title))
            {
                throw new BadRequestException("Nie podano wszystkich danych");
            }

            if (request.Release_Date > DateTime.Now)
            {
                throw new BadRequestException("Podano złą datę");
            }

            if (_authorRepositorie.GetByIdAsync(request.AuthorId) == null)
            {
                throw new BadRequestException("Podany autor nie istnieje");
            }

            bookFromDb.Title = request.Title;
            bookFromDb.Description = request.Description;
            bookFromDb.Release_Date = request.Release_Date;
            bookFromDb.AuthorId = request.AuthorId;

            await _bookRepositorie.SaveChangesAsync();
        }
    }
}
