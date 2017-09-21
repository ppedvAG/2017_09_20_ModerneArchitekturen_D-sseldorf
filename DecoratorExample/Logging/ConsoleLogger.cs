using System;

namespace DecoratorExample.Logging
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
}
