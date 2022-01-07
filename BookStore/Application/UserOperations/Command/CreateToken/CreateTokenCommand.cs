using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using BookStore.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace BookStore.Application.UserOperations.Commnand.CreateToken{

    public class CreateTokenCommand{
        private readonly IBookStoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration ;

        public CreateTokenModel Model { get; set; }
        public CreateTokenCommand(IBookStoreDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle(){
            var user =_context.Users.SingleOrDefault(x => x.Email==Model.Email && x.Password==Model.Password );
            if(user is not null){
                TokenHandler tokenHandler =new TokenHandler(_configuration);
               Token token = tokenHandler.CreateAccessToken(user);
                user.RefreshToken= token.RefreshToken;
                user.RefreshTokenExpireDate= token.Exparition.AddMinutes(5);
                _context.SaveChanges();
                return token;
                

            }else{
                throw new InvalidOperationException("Şifre-Email hatalı");
            }

        }


    }

    public class CreateTokenModel{
        public string Email { get; set; }
        public string Password { get; set; }
    }
}