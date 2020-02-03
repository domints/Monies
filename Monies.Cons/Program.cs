using System;
using Microsoft.Extensions.Logging;

namespace Monies.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceInjector.Configure();
            ServiceInjector.StartScope();

            Console.WriteLine("HW!?");

            ServiceInjector.KillScope();
        }
    }
}
