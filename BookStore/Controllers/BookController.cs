using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.BookOperations;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBookById;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.CreateBook;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
 {
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper ;
        public BookController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        [HttpGet]
    public  IActionResult GetBooks(){
     GetBooksQuery getBookQuery = new GetBooksQuery(_context,_mapper);
     var books = getBookQuery.Handle();
     return Ok(books);

    }
    
    [HttpGet("{id}")]
    
    public IActionResult GetById( int id){
        GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
        GetBookByIdQueryValidator validate = new GetBookByIdQueryValidator();
        query.Id = id;
        try{
        validate.ValidateAndThrow(query);
        var book  =query.Handle(id);
                return Ok(book);
}
        catch(Exception ex ){
            return BadRequest(ex.Message);
        }


    }
    [HttpPost]

    public IActionResult AddBook([FromBody] CreateBookModel newbook){
 
        CreateBookCommand command = new CreateBookCommand(_context,_mapper);
        try{
        command.Model= newbook;
        CreateBookCommandValidator validate = new CreateBookCommandValidator();
        validate.ValidateAndThrow(command);
        command.Handle();}catch(Exception ex){
            return BadRequest(ex.Message);
        }

        return Ok();

    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook){
        UpdateBookCommand command = new UpdateBookCommand(_context);
        UpdateBookCommandValidator validate = new UpdateBookCommandValidator();
        command.Model=updatedBook;
        command.Id=id;
        try{
        validate.ValidateAndThrow(command);
        command.Handle(); 
        return Ok();}
        catch(Exception  ex){
            return BadRequest(ex.Message);
        }

    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id){
        DeleteBookCommand command = new DeleteBookCommand(_context);
        DeleteBookCommandValidator validate = new DeleteBookCommandValidator();
        try{
            validate.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }catch(Exception ex)
        {

            return BadRequest(ex.Message);
         }
        // var book =_context.Books.SingleOrDefault(x=>x.Id==id);
        // if(book is null){
        //     return BadRequest();
        // }
        // _context.Books.Remove(book);
        // _context.SaveChanges();
        // return Ok();
    }
    
    }
}