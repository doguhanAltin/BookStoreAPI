using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace TestSetup {

    public class CommonTextFixture{
        public BookStoreDBContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTextFixture(){
            var options = new DbContextOptionsBuilder<BookStoreDBContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context = new BookStoreDBContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }

    }
}