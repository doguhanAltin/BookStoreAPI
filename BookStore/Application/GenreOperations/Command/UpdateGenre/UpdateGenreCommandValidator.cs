using FluentValidation;

namespace BookStore.Application.GenreOperations.Command.UpdateGenre{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {
        public UpdateGenreCommandValidator(){
            RuleFor(command => command.Model.Name).MinimumLength(4).When(command=> command.Model.Name.Trim() != string.Empty);
            RuleFor(com => com.Id).GreaterThan(0);

        }
    }
}