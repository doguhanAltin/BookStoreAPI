using System;
using BookStore.DBOperations;
using BookStore.Entities;

namespace TestSetup {

    public static class Books {

        public static void AddBooks(this BookStoreDBContext context){
            context.Books.AddRange(
            new Book{//Id=1,
            Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12),AuthorId=1},
            new Book{//Id=2,
            Title="Herland",GenreId=2,PageCount=250, PublishDate= new DateTime(2010,05,23),AuthorId=1},
            new Book{//Id=3,
            Title="Learn Startup",GenreId=1,PageCount=200, PublishDate= new DateTime(2001,06,12),AuthorId=2}
            );

        }


    }
}