using System;
using FluentValidation;

namespace BookStore.Application.AuthorOperations.Command.UpdateAuthor{

    public class  UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>{
        public UpdateAuthorCommandValidator(){
            RuleFor(x=>x.Id).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x=>x.Model.Surname).MinimumLength(2);
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
        }
        
    }
}