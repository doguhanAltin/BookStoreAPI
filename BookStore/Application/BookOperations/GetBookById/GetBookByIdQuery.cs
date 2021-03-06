using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.GetBookById {
    public class  GetBookByIdQuery {
        private readonly IBookStoreDBContext  dbContext ;
        public int Id { get; set; }
        private readonly IMapper _mapper;
        public GetBookByIdQuery(IBookStoreDBContext context, IMapper mapper)
        {
            dbContext = context;
            _mapper = mapper;
        }
        public BookViewModelId Handle(int id ){
         var book = dbContext.Books.Include(x=> x.Genre).Where(x=> x.Id ==id).SingleOrDefault();
         if(book is null){
             throw new InvalidOperationException("Öyle Bir Kitap Yok");
         }
         BookViewModelId vm = _mapper.Map<BookViewModelId>(book);//new BookViewModelId();
        // vm.Title= book.Title;
        //  vm.Genre= ((Genres)book.GenreId).ToString();
        //  vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
        //  vm.PageCount= book.PageCount;
         return vm;
        }
    }
  public class BookViewModelId{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
}

}