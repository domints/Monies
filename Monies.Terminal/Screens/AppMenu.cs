using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class AppMenu : MenuBar
    {
        public static readonly MenuBarItem[] DefaultMenu = new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => { Quit(); })
            })
        };

        public AppMenu()
            : base(DefaultMenu)
        {

        }

        public AppMenu(MenuBarItem[] menu)
            : base(menu)
        {
            
        }

        public static void Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit", "Are you sure you want to quit this app?", "Yes", "No");
            if(n == 0) 
            {
                Application.Driver.End();
                System.Environment.Exit(0);
            }
        }
    }
}