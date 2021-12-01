using System;
using FluentValidation;

namespace BookStore.BookOperations{
    class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>{
        public DeleteBookCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0);
        }

        private void RuleFor()
        {
            throw new NotImplementedException();
        }
    }
}