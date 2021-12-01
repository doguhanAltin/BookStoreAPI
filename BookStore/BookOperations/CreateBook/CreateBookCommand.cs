using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using BookStore;

namespace BookStore.BookOperations.CreateBook{

    public class CreateBookCommand{
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext dBContext ;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDBContext context, IMapper mapper)
        {
            dBContext = context;
            _mapper = mapper;
        }
        public void Handle(){
          var book = dBContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if(book is not null){
                throw new InvalidOperationException("Kitap zaten var");
            }
            book=_mapper.Map<Book>(Model);
            
            // book.Title=Model.Title;
            // book.PublishDate=Model.PublishDate;
            // book.PageCount=Model.PageCount;
            // book.GenreId=Model.GenreId;
            dBContext.Books.Add(book);
            dBContext.SaveChanges();
        }

    }

    public class CreateBookModel{
        public string Title { get; set; }
        public int PageCount {get; set;}
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}
