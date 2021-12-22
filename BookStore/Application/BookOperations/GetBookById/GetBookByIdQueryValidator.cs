using BookStore.Application.BookOperations.GetBookById;
using FluentValidation;

namespace BookStore.Application.BookOperations {
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>{
        
        public GetBookByIdQueryValidator(){
            RuleFor(command => command.Id).NotNull().GreaterThan(0);
        }
    }
}