using System;
using System.Linq;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace BookStore.DBOperations{
    public class DataGenerator {
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>())){
                if(context.Books.Any()){
                    return;
                }

            context.Genres.AddRange(new Genre{Name="Personal Dev"},new Genre {Name="Sci-Fci"});
            context.Authors.AddRange(new Author{Name="Doğuhan",Surname="Altın",BirthDate=new DateTime(1999,06,20)},
                                     new Author{Name="Charles",Surname="Dickens",BirthDate=new DateTime(1969,06,20)},
                                      new Author{Name="sadsa",Surname="Dins",BirthDate=new DateTime(1900,06,20)});



                context.Books.AddRange(
                new Book{//Id=1,
                Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12),AuthorId=1},
            new Book{//Id=2,
            Title="Herland",GenreId=2,PageCount=250, PublishDate= new DateTime(2010,05,23),AuthorId=1},
            new Book{//Id=3,
            Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12),AuthorId=2}
                );
                context.SaveChanges();
            }
        }
    }
}