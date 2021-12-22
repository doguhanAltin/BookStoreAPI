using FluentValidation;

namespace BookStore.Application.AuthorOperations.Query.GetAuthorDetail{

    public class GetAuthorDetailQueryValidator: AbstractValidator<GetAuthorDetailQuery>{
        public  GetAuthorDetailQueryValidator(){
            RuleFor(x=>x.Id).GreaterThan(0);
        }

    }
}