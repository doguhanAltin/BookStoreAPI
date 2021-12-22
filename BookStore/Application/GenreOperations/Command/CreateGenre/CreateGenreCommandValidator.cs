using FluentValidation;

namespace BookStore.Application.GenreOperations.Command.CreateGenre{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>{

    public CreateGenreCommandValidator(){
        RuleFor(command=> command.Model.Name).MinimumLength(4);
    }
    
    
    }
}