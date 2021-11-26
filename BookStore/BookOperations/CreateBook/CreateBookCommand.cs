using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using BookStore.DBOperations;

namespace BookStore.BookOperations.CreateBook{

    public class CreateBookCommand{
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext dBContext ;
        public CreateBookCommand(BookStoreDBContext context){
            dBContext=context;
        }
        public void Handle(){
          var book = dBContext.Books.SingleOrDefault(x=>x.Title==Model.Title);
            if(book is not null){
                throw new InvalidOperationException("Kitap zaten var");
            }
            book=new Book();
            book.Title=Model.Title;
            book.PublishDate=Model.PublishDate;
            book.PageCount=Model.PageCount;
            book.GenreId=Model.GenreId;
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
