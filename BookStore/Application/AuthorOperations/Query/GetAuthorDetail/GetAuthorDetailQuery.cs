using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Query.GetAuthorDetail{

    public class GetAuthorDetailQuery{

        private readonly IBookStoreDBContext _context ;
        private readonly IMapper _mapper;

        public int Id { get; set; }
        public GetAuthorDetailQuery(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public GetAuthorDetailModel Handle(){
            var author = _context.Authors.FirstOrDefault( x => x.Id==Id);
            if(author is null){
                throw new InvalidOperationException("Öyle bir yazar yok");
            }

            GetAuthorDetailModel vm = _mapper.Map<GetAuthorDetailModel>(author);
            return vm;
        }








    }

    public class GetAuthorDetailModel{

        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname {get; set;}

        public DateTime BirthDate { get; set; }
    }





}