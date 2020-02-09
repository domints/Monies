﻿using System;
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
            Application.Init();
            ScreenManager.Init();
            Application.Run();
            ServiceInjector.KillScope();
            
        }
    }
}
