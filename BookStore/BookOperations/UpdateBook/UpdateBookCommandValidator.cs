using System;
using BookStore.BookOperations.UpdateBook;
using FluentValidation;

namespace BookStore.BookOperations{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>{
        public UpdateBookCommandValidator(){
            RuleFor(command => command.Id).NotNull().GreaterThan(0);
            RuleFor(command => command.Model.Title).NotNull();
            RuleFor(command => command.Model.PageCount).NotNull().GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotNull().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.GenreId).NotNull().GreaterThan(0);
            

        }
    }

}