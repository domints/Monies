using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public static class ScreenManager
    {
        private static Window _currentScreen;

        public static void Init(int width, int height)
        {
            Console.SetWindowSize(width, height);
            var mainWindow = ServiceInjector.GetService<MainWindow>();
            Console.Title = mainWindow.Title.ToString();
            _currentScreen = mainWindow;
            ShowScreen(Application.Top, mainWindow);
        }

        /// <summary>
        /// Shows screen
        /// </summary>
        /// <typeparam name="TScreen"></typeparam>
        /// <deprecated></deprecated>
        public static void Show<TScreen>()
            where TScreen : IScreen
        {
            var screen = ServiceInjector.GetService<TScreen>();
        }

        public static void ShowFullScreen<TScreen>()
            where TScreen : BaseFullScreenWindow
        {
            var screen = ServiceInjector.GetService<TScreen>();
            var newLevel = new Toplevel(Application.Current.Frame);
            ShowScreen(newLevel, screen);
            _currentScreen = screen;
            Application.Run(newLevel);
        }

        private static void ShowScreen(Toplevel top, BaseFullScreenWindow screen)
        {
            top.Add(
                screen,
                new AppMenu(screen.Menu),
                new Label("(?) Press F9 (on Unix ESC+9 is an alias) to activate the menubar") { Y = Console.WindowHeight - 2, X = 5 }
            );
        }
    }
}