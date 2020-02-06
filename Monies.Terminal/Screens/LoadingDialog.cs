using System.Threading;
using System.Threading.Tasks;
using NStack;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class LoadingDialog : Dialog
    {
        private readonly Label _lbl;
        public LoadingDialog() : base("Loading...", 40, 10, new Button[0])
        {
            _lbl = new Label(2, 2, "Loading");
            Add(_lbl);
        }

        public void Show()
        {
            Task.Run(() => {
                Thread.Sleep(5000);
                base.ProcessKey(new KeyEvent(Key.Esc));
                Application.Refresh();
            });
            Application.Run(this);
        }

        public override bool ProcessKey(KeyEvent kb)
        {
            return true;
        }
    }
}