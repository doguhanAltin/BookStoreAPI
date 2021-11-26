using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using BookStore.DBOperations;

namespace BookStore.BookOperations.GetBooks{

public class GetBooksQuery{
     private readonly  BookStoreDBContext dBContext ;
    public GetBooksQuery( BookStoreDBContext context){
        dBContext=context;
    }
    public List<BookViewModel> Handle(){
        var books = dBContext.Books.OrderBy(x=>x.Id).ToList<Book>();
        List<BookViewModel> vm = new List<BookViewModel>();
        books.ForEach(item =>{
            vm.Add(new BookViewModel(){
                Title= item.Title,
                PageCount=item.PageCount,
                PublishDate = item.PublishDate.Date.ToString("dd/MM/yyy"),
                Genre= ((Genres)item.GenreId).ToString()

            });

        });
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
