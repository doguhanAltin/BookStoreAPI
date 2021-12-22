using FluentValidation;

namespace BookStore.Application.AuthorOperations.Command.DeleteAuthor{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand> {
        public DeleteAuthorCommandValidator(){
            RuleFor(x=>x.Id).GreaterThan(0);
        }
    }
}