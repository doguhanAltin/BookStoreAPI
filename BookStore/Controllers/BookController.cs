using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBookById;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
 {
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private readonly BookStoreDBContext _context;
        public BookController(BookStoreDBContext context){
            _context=context;

        }




    [HttpGet]
    public  IActionResult GetBooks(){
     GetBooksQuery getBookQuery = new GetBooksQuery(_context);
     var books = getBookQuery.Handle();
     return Ok(books);

    }
    
    [HttpGet("{id}")]
    
    public IActionResult GetById( int id){
        GetBookByIdQuery query = new GetBookByIdQuery(_context);
        try{
        var book  =query.Handle(id);
                return Ok(book);
}
        catch(Exception ex ){
            return BadRequest(ex.Message);
        }


    }
    [HttpPost]

    public IActionResult AddBook([FromBody] CreateBookModel newbook){
 
        CreateBookCommand command = new CreateBookCommand(_context);
        try{
        command.Model= newbook;
        command.Handle();}catch(Exception ex){
            return BadRequest(ex.Message);
        }

        return Ok();

    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook){
        UpdateBookCommand command = new UpdateBookCommand(_context);
        command.Model=updatedBook;
        try{
        command.Handle(id); 
        return Ok();}
        catch(Exception  ex){
            return BadRequest(ex.Message);
        }

    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id){
        var book =_context.Books.SingleOrDefault(x=>x.Id==id);
        if(book is null){
            return BadRequest();
        }
        _context.Books.Remove(book);
        _context.SaveChanges();
        return Ok();
    }
    
    }
}