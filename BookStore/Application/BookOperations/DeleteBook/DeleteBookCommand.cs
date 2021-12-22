using System;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Application.BookOperations {
    public class DeleteBookCommand {

     private readonly BookStoreDBContext dbContext ;
     public int Id { get; set; }
     public DeleteBookCommand(BookStoreDBContext _context){
         dbContext=_context;

     }

    public void Handle(){
        var book =  dbContext.Books.SingleOrDefault(x => x.Id == Id);
        if(book is null){
            throw new InvalidOperationException("Böyle bir kitap namevcut");
        }
        dbContext.Books.Remove(book);
        dbContext.SaveChanges();
    }

    }
}