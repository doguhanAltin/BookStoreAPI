using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Query.GetGenreDetail{
    public class GetGenreDetailQuery{

            public int GenreId { get; set; }
            private readonly IBookStoreDBContext _context ;
            private readonly IMapper _mapper ;
        public GetGenreDetailQuery(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  GenreDetailViewModel Handle(){
        var genre = _context.Genres.SingleOrDefault(x=>x.Id==GenreId);
        if(genre is null){  
            throw new InvalidOperationException("Öyle bir Genre yok");

        }
        GenreDetailViewModel rgenre = _mapper.Map<GenreDetailViewModel>(genre);
        return rgenre;

        }

    }

    public class GenreDetailViewModel{

        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}