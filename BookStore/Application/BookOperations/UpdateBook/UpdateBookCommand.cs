using System;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Application.BookOperations.UpdateBook{
    public class UpdateBookCommand{
    public UpdateBookModel Model { get; set; }
public int Id { get; set; }
    private readonly IBookStoreDBContext dbContext ;
    public UpdateBookCommand(IBookStoreDBContext context){
        dbContext=context;
    }
    
    
    public void Handle ( ){
        var book = dbContext.Books.SingleOrDefault(x=> x.Id==Id);
    if(book is  null){
        throw new InvalidOperationException("Söyle Buldun mu ? Aradağın kitabı Söyle ");
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