using System;

namespace BookStore.Services {
    public class DBLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] "+message);
        }
    }
}