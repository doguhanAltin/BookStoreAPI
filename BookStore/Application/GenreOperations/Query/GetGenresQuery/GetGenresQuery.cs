using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.GenreOperations.Query.GetGenresQuery{
    public class GetGenresQuery{
        public BookStoreDBContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public GetGenresQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle(){
            var vm = _context.Genres.OrderBy(x=>x.Id).ToList<Genre>();
            List<GenreViewModel> genres = _mapper.Map<List<GenreViewModel>>(vm);
            return genres;
        }

    }

public class GenreViewModel {
    public int Id { get; set; }
    public string  Name { get; set; }
}
}