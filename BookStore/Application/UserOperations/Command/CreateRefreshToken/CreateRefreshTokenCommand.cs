using System;
using System.Linq;
using AutoMapper;
using BookStore.DBOperations;
using BookStore.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace BookStore.Application.UserOperations.Commnand.CreateRefreshToken{

    public class CreateRefreshTokenCommand{
        private readonly IBookStoreDBContext _context;

        private readonly IConfiguration _configuration ;

        public string Model { get; set; }
        public CreateRefreshTokenCommand(IBookStoreDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Token Handle(){
            var user =_context.Users.FirstOrDefault(x => x.RefreshToken==Model && x.RefreshTokenExpireDate>DateTime.Now );
            if(user is not null){
                TokenHandler tokenHandler =new TokenHandler(_configuration);
               Token token = tokenHandler.CreateAccessToken(user);
                user.RefreshToken= token.RefreshToken;
                user.RefreshTokenExpireDate= token.Exparition.AddMinutes(5);
                _context.SaveChanges();
                return token;
                

            }else{
                throw new InvalidOperationException("Zaman Aşımı");
            }

        }


    }

}