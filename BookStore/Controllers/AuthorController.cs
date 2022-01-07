using System.Collections.Generic;
using AutoMapper;
using BookStore.Application.AuthorOperations.Command.CreateAuthor;
using BookStore.Application.AuthorOperations.Command.DeleteAuthor;
using BookStore.Application.AuthorOperations.Command.UpdateAuthor;
using BookStore.Application.AuthorOperations.Query;
using BookStore.Application.AuthorOperations.Query.GetAuthorDetail;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers {
    [ApiController]
    [Route("[controller]s")]


    public class AuthorController : ControllerBase {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthor(){

            GetAuthorQuery getAuthorQuery = new GetAuthorQuery(_context,_mapper);
            List<GetAuthorModel> vm = getAuthorQuery.Handle();
            return Ok(vm);
        }

        [HttpGet("{id}")]

        public IActionResult GetAuthorDetail([FromRoute] int id){
            GetAuthorDetailQuery getAuthorDetail = new GetAuthorDetailQuery(_context,_mapper);
            GetAuthorDetailQueryValidator validate = new GetAuthorDetailQueryValidator();
            getAuthorDetail.Id=id;
            validate.ValidateAndThrow(getAuthorDetail);
            GetAuthorDetailModel author=  getAuthorDetail.Handle();
            
            return Ok(author);
        }


        [HttpPost]

        public IActionResult CreateAuthor([FromBody] CreateAuthorModel model){
            CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand(_context,_mapper);
            createAuthorCommand.Model=model;
            CreateAuthorCommandValidator validate =new CreateAuthorCommandValidator();
            validate.ValidateAndThrow(createAuthorCommand);
            createAuthorCommand.Handle();
            return Ok();

        }

        [HttpPut("{id}")]

        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel model, [FromRoute] int id ){
            UpdateAuthorCommand updateAuthorCommand = new UpdateAuthorCommand(_context,_mapper);
            updateAuthorCommand.Id=id;
            updateAuthorCommand.Model=model;
            UpdateAuthorCommandValidator validate = new UpdateAuthorCommandValidator();
            validate.ValidateAndThrow(updateAuthorCommand);
            updateAuthorCommand.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteAuthor([FromRoute] int id ){
            DeleteAuthorCommand deleteAuthor = new DeleteAuthorCommand(_context);
            deleteAuthor.Id=id;
            DeleteAuthorCommandValidator validate = new DeleteAuthorCommandValidator();
            validate.ValidateAndThrow(deleteAuthor);
            deleteAuthor.Handle();
            return Ok();
        }








    }
}