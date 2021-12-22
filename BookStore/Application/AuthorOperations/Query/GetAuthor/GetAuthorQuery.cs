using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Query{
 public class GetAuthorQuery{

    private readonly BookStoreDBContext _context;
    private readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    public List<GetAuthorModel> Handle(){
        var authors = _context.Authors.OrderBy(x=>x.Id).ToList<Author>();
        List<GetAuthorModel> vm = _mapper.Map<List<GetAuthorModel>>(authors);
        return vm;

    }
    
    }

 public class GetAuthorModel{

    public int Id { get; set; }
    public string Name{ get; set; }

    public DateTime BirthDate { get; set; }
 }


}