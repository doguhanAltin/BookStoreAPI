using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Command.UpdateGenre{

    public class UpdateGenreCommand{
        private readonly BookStoreDBContext _context ;

        public UpdateGenreModel Model { get; set; }
        public int Id { get; set; }

        public UpdateGenreCommand(BookStoreDBContext context)
        {
            _context = context;

        }



        public  void Handle(){
            var genre = _context.Genres.SingleOrDefault(x => x.Id==Id);
            if(genre is null){
                throw new InvalidOperationException("Böyle bir kitap Namevcut");
            }

            if(_context.Genres.Any(x => x.Name.ToLower()== Model.Name.ToLower() && x.Id != Id )){
                   throw new InvalidOperationException("Böyle bir kitap Namevcut");

            }
        genre.Name = Model.Name != default ? Model.Name : genre.Name;
        genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;
        _context.SaveChanges();




        }


    }

    public class UpdateGenreModel{
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }


}