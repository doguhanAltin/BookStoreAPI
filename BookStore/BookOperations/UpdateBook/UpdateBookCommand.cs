using System;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.BookOperations.UpdateBook{
    class UpdateBookCommand{
    public UpdateBookModel Model { get; set; }
    private readonly BookStoreDBContext dbContext ;
    public UpdateBookCommand(BookStoreDBContext context){
        dbContext=context;
    }
    
    
    public void Handle (int id ){
        var book = dbContext.Books.SingleOrDefault(x=> x.Id==id);
    if(book is  null){
        throw new InvalidOperationException("Böyle bir kitap namevcut ");
    }
    book.GenreId = Model.GenreId != default? Model.GenreId:book.GenreId;
    book.PageCount = Model.PageCount != default? Model.PageCount:book.PageCount;
    book.Title = Model.Title != default? Model.Title:book.Title;
    book.PublishDate = Model.PublishDate != default? Model.PublishDate:book.PublishDate;
    dbContext.SaveChanges();
    
    
    
    }
    
    }

    
    public class UpdateBookModel {
        public string Title { get; set; }
        public int PageCount {get; set;}
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}