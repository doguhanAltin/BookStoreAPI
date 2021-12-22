using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Command.UpdateAuthor{

    public class UpdateAuthorCommand {
        public int Id { get; set; }
        public UpdateAuthorModel Model { get; set; }

    
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void  Handle(){
            var author = _context.Authors.SingleOrDefault(x=>x.Id==Id);
            if(author is null){
                throw new InvalidOperationException("Böyle bir Yazar Yok");
            }
            author.Name = Model.Name == default ? author.Name: Model.Name;
            author.Surname = Model.Surname== default ? author.Surname: Model.Surname;
            author.BirthDate = Model.BirthDate == default ? author.BirthDate : Model.BirthDate;
            _context.SaveChanges();
        }



    }
    public class UpdateAuthorModel {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDate {get; set;}
    }
}