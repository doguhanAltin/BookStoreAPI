using AutoMapper;
using BookStore.Application.UserOperations.Commnand.CreateRefreshToken;
using BookStore.Application.UserOperations.Commnand.CreateToken;
using BookStore.Application.UserOperations.Commnand.CreateUser;
using BookStore.DBOperations;
using BookStore.TokenOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.Controllers {
 [ApiController]
 [Route("[controller]s")]
    public class UserController:ControllerBase {
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper ;

        private readonly IConfiguration _configuration;

        public UserController(IBookStoreDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]

        public IActionResult CreateUser([FromBody] CreateUserModel user){
            CreateUserCommand createUser = new CreateUserCommand(_context,_mapper);
            createUser.Model= user;
            createUser.Handle();

            return Ok();
        } 
        [HttpPost("connect/token")]

        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login){
            CreateTokenCommand createTokenCommand = new CreateTokenCommand(_context,_mapper,_configuration);
            createTokenCommand.Model=login;
            var token = createTokenCommand.Handle();
            return token;

        }
        [HttpGet("RefreshToken")]

        public ActionResult<Token> RefrehToken([FromQuery] string reftoken){
            CreateRefreshTokenCommand createRefreshTokenCommand = new CreateRefreshTokenCommand(_context,_configuration);
            createRefreshTokenCommand.Model=reftoken;
            var token = createRefreshTokenCommand.Handle();
            return token;

        }


    }
}