using System;
using FluentValidation;

namespace BookStore.Application.AuthorOperations.Command.CreateAuthor{

    public class  CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>{
        public CreateAuthorCommandValidator(){
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x=>x.Model.Surname).MinimumLength(2);
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
        }
        
    }

}