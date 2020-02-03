using System;
using Microsoft.Extensions.Logging;

namespace Monies.Console
{
    class Program
    {
        static ILogger _logger;
        static void Main(string[] args)
        {
            ServiceInjector.Configure();
            _logger = ServiceInjector.Logger<Program>();
            _logger.LogError("Hello World!");
        }
    }
}
