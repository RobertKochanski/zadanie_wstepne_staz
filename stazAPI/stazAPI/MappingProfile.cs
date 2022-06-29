using AutoMapper;
using stazDAL.Entities;
using stazServices.ViewModels;

namespace stazAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>();

            CreateMap<Author, AuthorWithBooksViewModel>()
                .ForMember(b => b.BookViewModel, opt => opt.MapFrom(s => s.Books));

            CreateMap<Book, BookViewModel>();

            CreateMap<Book, BookWithAuthorViewModel>()
                .ForMember(a => a.AuthorViewModel, opt => opt.MapFrom(s => s.Author));

        }
    }
}
