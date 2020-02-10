using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Monies.Database;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class NewWindow : BaseFullScreenWindow
    {
        public override MenuBarItem[] Menu => AppMenu.DefaultMenu;

        private readonly MoniesDbContext _cx;
        private readonly ILogger<NewWindow> _logger;

        public NewWindow(ILogger<NewWindow> logger, MoniesDbContext cx)
            : base("New Window")
        {
            _cx = cx;
            var lvl = new Toplevel();
            Add(new Label(0, 0, "CFFFFFFFFFF"));
            Add(new Button (0, 1, "Test DB", is_default: true) { Clicked = () => { TestDb(); } });
            _logger = logger;
        }

        private void TestDb()
        {
            _logger.LogInformation("Testing database");
            var result = Load(_cx.UserSettings.ToListAsync());
            _logger.LogInformation("Got {0} entries.", result.Count);
        }
    }
}