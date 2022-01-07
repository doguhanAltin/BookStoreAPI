using System;
using System.Linq;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.AuthorOperations.Command.DeleteAuthor{

    public class DeleteAuthorCommand{

        public int Id { get; set; }
        private readonly IBookStoreDBContext _context;

        public DeleteAuthorCommand(IBookStoreDBContext context)
        {
            _context = context;
        }
        public void Handle(){
            var aut = _context.Authors.SingleOrDefault(x=>x.Id==Id);
            if(aut is null){
                throw new InvalidOperationException("Böyle bir yazar yok");
            }
            if(_context.Books.Include(x => x.Author).Any(x => x.AuthorId == Id)){
            throw new InvalidOperationException("Kitabı olan bir yazar silinemez"); 
            }
        _context.Authors.Remove(aut);
        _context.SaveChanges();
        }
        

    }


    

}