using System;
using Monies.Terminal.Screens;
using Terminal.Gui;

namespace Monies.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadKey();
            ServiceInjector.Configure();
            ServiceInjector.StartScope();
            try {
                Application.Init();
                ScreenManager.Init();
                Application.Run();
            }
            catch
            {
                Application.Driver.End();
                ServiceInjector.KillScope();
            }
        }
    }
}
