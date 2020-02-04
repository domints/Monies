using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class NewWindow : BaseFullScreenWindow
    {
        public NewWindow()
            : base("New Window")
        {
            var lvl = new Toplevel();
            Add(new Label(0, 0, "CFFFFFFFFFF"));
        }

        public override MenuBarItem[] Menu => AppMenu.DefaultMenu;
    }
}