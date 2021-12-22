using FluentValidation;

namespace BookStore.Application.GenreOperations.Command.DeleteCommand{
    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand> {
        public DeleteGenreCommandValidator (){
            RuleFor(x=>x.Id).GreaterThan(0);
        }
    }
}