using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Command.CreateAuthor{
    public class CreateAuthorCommand  {

        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var aut =_context.Authors.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname && x.BirthDate==Model.BirthDate);
            if(aut is not null){
                throw new InvalidOperationException("Böyle bir yazar var");
            }
            Author auts= _mapper.Map<Author>(Model);
            _context.Authors.Add(auts);
            _context.SaveChanges();

        }


    }

    public class CreateAuthorModel{
        public string Name { get; set; }

        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}