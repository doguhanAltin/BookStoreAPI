using System;

namespace BookStore.TokenOperations.Models{

    public class Token {
        public string AccessToken { get; set; }
        public DateTime Exparition {get; set;}
        public string RefreshToken {get; set;}
    }
}