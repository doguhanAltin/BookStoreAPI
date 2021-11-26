using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace BookStore.DBOperations{
    public class DataGenerator {
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>())){
                if(context.Books.Any()){
                    return;
                }
                context.Books.AddRange(
                new Book{//Id=1,
                Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12)},
            new Book{//Id=2,
            Title="Herland",GenreId=2,PageCount=250, PublishDate= new DateTime(2010,05,23)},
            new Book{//Id=3,
            Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12)}
                );
                context.SaveChanges();
            }
        }
    }
}