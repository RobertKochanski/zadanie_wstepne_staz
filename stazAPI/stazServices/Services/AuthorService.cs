using AutoMapper;
using stazAPI.Service;
using stazDAL.Entities;
using stazDAL.Repositories.Interfaces;
using stazServices.RestModels;
using stazServices.Services.Interfaces;
using stazServices.ViewModels;

namespace stazServices.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepositorie _authorRepositorie;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepositorie authorRepositorie, IMapper mapper)
        {
            _authorRepositorie = authorRepositorie;
            _mapper = mapper;
        }

        public async Task AddAuthor(AddAuthorRequest request)
        {
            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.SurName))
            {
                throw new BadRequestException("Nie podano wszystkich danych");
            }

            await _authorRepositorie.AddAsync(new Author()
            {
                FirstName = request.FirstName,
                SurName = request.SurName
            });
        }

        public async Task<AuthorWithBooksViewModel> GetAuthor(Guid id)
        {
            var authorFromDb = await _authorRepositorie.GetByIdAsync(id);

            if (authorFromDb == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<AuthorWithBooksViewModel>(authorFromDb);
        }

        public async Task<List<AuthorViewModel>> GetAuthors()
        {
            var authorsFromDb = await _authorRepositorie.GetAsync();
            return _mapper.Map<List<AuthorViewModel>>(authorsFromDb);
        }

        public async Task RemoveAuthor(Guid id)
        {
            var authorFromDb = await _authorRepositorie.GetByIdAsync(id);

            if (authorFromDb == null)
            {
                throw new BadRequestException("Podany autor nie istnieje");
            }

            await _authorRepositorie.DeleteAsync(authorFromDb);
        }

        public async Task UpdateAuthor(Guid id, UpdateAuthorRequest request)
        {
            var authorFromDb = await _authorRepositorie.GetByIdAsync(id);

            if (authorFromDb == null)
            {
                throw new NotFoundException();
            }

            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.SurName))
            {
                throw new BadRequestException("Nie podano wszystkich danych");
            }

            authorFromDb.FirstName = request.FirstName;
            authorFromDb.SurName = request.SurName;

            await _authorRepositorie.SaveChangesAsync();
        }
    }
}
