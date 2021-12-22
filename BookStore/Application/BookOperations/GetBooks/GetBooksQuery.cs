using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.GetBooks{

public class GetBooksQuery{
     private readonly  BookStoreDBContext dBContext ;
     private readonly IMapper _mapper ;
        public GetBooksQuery(BookStoreDBContext context, IMapper mapper)
        {
            dBContext = context;
            _mapper = mapper;
        }
        public List<BookViewModel> Handle(){
        var books = dBContext.Books.Include(x => x.Genre).OrderBy(x=>x.Id).ToList<Book>();
        List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(books);
        // books.ForEach(item =>{
        //     vm.Add(new BookViewModel(){
        //         Title= item.Title,
        //         PageCount=item.PageCount,
        //         PublishDate = item.PublishDate.Date.ToString("dd/MM/yyy"),
        //         Genre= ((Genres)item.GenreId).ToString()

        //     });

        // });
        return  vm; 
    }


}
public class BookViewModel{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
}

}
