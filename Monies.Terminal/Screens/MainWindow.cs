using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class MainWindow : BaseFullScreenWindow
    {
        private protected override bool AskForEsc => true;
        public MainWindow()
            : base("Monies")
        {
            Add(new Label(0, 0, "XDD"));
            Add(new Button (0, 1, "Ok", is_default: true) { Clicked = () => { System.Diagnostics.Debug.WriteLine("newWin"); ScreenManager.ShowFullScreen<NewWindow>(); } });
        }

        public override MenuBarItem[] Menu => AppMenu.DefaultMenu;
    }
}