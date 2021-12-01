using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBookById;
using BookStore.BookOperations.GetBooks;

namespace BookStore.Common{
    public class MappingProfile : Profile
    {
      public MappingProfile(){
          CreateMap<CreateBookModel,Book>();
          CreateMap<Book,BookViewModelId>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>((Genres)src.GenreId).ToString()));
          CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>((Genres)src.GenreId).ToString()));      }
    }
}