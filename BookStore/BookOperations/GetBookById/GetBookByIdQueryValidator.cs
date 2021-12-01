using BookStore.BookOperations.GetBookById;
using FluentValidation;

namespace BookStore.BookOperations {
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>{
        
        public GetBookByIdQueryValidator(){
            RuleFor(command => command.Id).NotNull().GreaterThan(0);
        }
    }
}