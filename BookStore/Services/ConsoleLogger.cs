using System;

namespace BookStore.Services{
    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] "+message);
        }
    }
}