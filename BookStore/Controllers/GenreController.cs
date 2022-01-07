using AutoMapper;
using BookStore.Application.GenreOperations.Command.CreateGenre;
using BookStore.Application.GenreOperations.Command.DeleteCommand;
using BookStore.Application.GenreOperations.Command.UpdateGenre;
using BookStore.Application.GenreOperations.Query.GetGenreDetail;
using BookStore.Application.GenreOperations.Query.GetGenresQuery;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers {
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper ;
        public GenreController(IBookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetGenres(){
        GetGenresQuery getGenresQuery = new GetGenresQuery( _context ,_mapper);
        var genres =getGenresQuery.Handle();
        return Ok(genres);
        }

        [HttpGet("{id}")]

        public IActionResult GetGenreDetail([FromRoute] int id ){
            GetGenreDetailQuery getGenreDetailQuery  = new GetGenreDetailQuery(_context,_mapper);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            getGenreDetailQuery.GenreId=id;
            validator.ValidateAndThrow(getGenreDetailQuery);
            var genre =getGenreDetailQuery.Handle();
            return Ok(genre);

        }
        [HttpPost]

        public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre ){
            CreateGenreCommand createGenreCommand = new CreateGenreCommand(_context,_mapper);
            createGenreCommand.Model= newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(createGenreCommand);
            createGenreCommand.Handle();
            return Ok();

        }
        [HttpPut("{id}")]

        public IActionResult UpdateGenre([FromBody] UpdateGenreModel genre , [FromRoute] int id ){
            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_context);
            updateGenreCommand.Model=genre;
            updateGenreCommand.Id=id;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(updateGenreCommand);
            updateGenreCommand.Handle();
            return Ok();
        }
    
    
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre([FromRoute] int id ){
        DeleteGenreCommand deleteGenreCommand = new DeleteGenreCommand(_context);
        deleteGenreCommand.Id=id;
        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(deleteGenreCommand);
        deleteGenreCommand.Handle();
        return Ok();
    }    
    
    
    }


}