using System.Linq;
using BookStore.DBOperations;
using System;

namespace BookStore.Application.GenreOperations.Command.DeleteCommand{

    public class DeleteGenreCommand{
        private readonly IBookStoreDBContext _context;
        public int Id { get; set; }
        public DeleteGenreCommand(IBookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle(){
            var book = _context.Genres.SingleOrDefault(x => x.Id==Id);
            if(book is null){
                throw new InvalidOperationException("Bu Id'e sahip kitap yok");
            }
            _context.Genres.Remove(book);
            _context.SaveChanges();
        }
    }
}