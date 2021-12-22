using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using System;
using BookStore.Entities;

namespace BookStore.Application.GenreOperations.Command.CreateGenre{

    public class CreateGenreCommand{
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateGenreModel Model { get; set; }

        public CreateGenreCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var book = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if(book is not null){
                throw new InvalidOperationException("Aynı isme sahip genre zaten var");
            }
            book = _mapper.Map<Genre>(Model);
            _context.Genres.Add(book);
            _context.SaveChanges();
        }

    }

    public class CreateGenreModel{
        public string Name { get; set; }
    }


}