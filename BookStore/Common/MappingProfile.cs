using AutoMapper;
using BookStore.Application.AuthorOperations.Command.CreateAuthor;
using BookStore.Application.AuthorOperations.Query;
using BookStore.Application.AuthorOperations.Query.GetAuthorDetail;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBookById;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.GenreOperations.Command.CreateGenre;
using BookStore.Application.GenreOperations.Query;
using BookStore.Application.GenreOperations.Query.GetGenreDetail;
using BookStore.Application.GenreOperations.Query.GetGenresQuery;
using BookStore.Entities;

namespace BookStore.Common{
    public class MappingProfile : Profile
    {
      public MappingProfile(){
          //BOOK
          CreateMap<CreateBookModel,Book>();
          CreateMap<Book,BookViewModelId>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>src.Genre.Name));
          CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>src.Genre.Name));  
          
          //GENRE
          CreateMap<Genre,GenreViewModel >();
          CreateMap<CreateGenreModel, Genre>();
          CreateMap<Genre,GenreDetailViewModel>();

          //Author
         CreateMap<Author,GetAuthorModel>();
         CreateMap<Author,GetAuthorDetailModel>();
         CreateMap<CreateAuthorModel,Author>();
          
              }
    }
}