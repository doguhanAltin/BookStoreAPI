using System;
using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.DBOperations;
using BookStore.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperations.Commands.CreateCommand{

    public class CreateBookCommandTest: IClassFixture<CommonTextFixture>{
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTextFixture fixture){
            _context=fixture.Context;
            _mapper = fixture.Mapper;

        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn(){
            var book = new Book{Title="sa",PageCount=100, PublishDate= new System.DateTime(1990,06,06),GenreId=1,AuthorId=2};
            _context.Books.Add(book);
            _context.SaveChanges();
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model=new CreateBookModel{Title=book.Title};
            

            FluentActions.Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>().And.Message
                .Should()
                .Be("Kitap zaten var");
        }

    }
}