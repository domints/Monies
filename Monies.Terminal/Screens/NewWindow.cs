using System.Linq;
using Microsoft.EntityFrameworkCore;
using Monies.Database;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class NewWindow : BaseFullScreenWindow
    {
        public override MenuBarItem[] Menu => AppMenu.DefaultMenu;

        private readonly MoniesDbContext _cx;

        public NewWindow(MoniesDbContext cx)
            : base("New Window")
        {
            _cx = cx;
            var lvl = new Toplevel();
            Add(new Label(0, 0, "CFFFFFFFFFF"));
            Add(new Button (0, 1, "Test DB", is_default: true) { Clicked = () => { TestDb(); } });
        }

        private void TestDb()
        {
            Load(_cx.UserSettings.ToListAsync());
        }
    }
}