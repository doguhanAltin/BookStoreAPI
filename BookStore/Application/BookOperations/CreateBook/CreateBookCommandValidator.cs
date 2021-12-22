using System;
using BookStore.Application.BookOperations.CreateBook;
using FluentValidation;

namespace BookStore.Application.BookOperations.CreateBook{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>{
        public CreateBookCommandValidator(){
            RuleFor(command => command.Model.GenreId).NotNull().GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotNull();
            RuleFor(command => command.Model.PublishDate.Date).LessThan(DateTime.Now.Date);
        }
    }
}