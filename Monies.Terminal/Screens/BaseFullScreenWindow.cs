using System;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public abstract class BaseFullScreenWindow : Window, IScreen
    {
        private protected virtual bool AskForEsc => false;
        public BaseFullScreenWindow(string title)
            : base(title)
        {
            X = 0;
            Y = 1;
            Width = Dim.Fill();
            Height = Dim.Fill() - 1;
        }

        public override bool ProcessKey(KeyEvent keyEvent)
        {
            if(keyEvent.Key == Key.Esc)
            {
                if(AskForEsc)
                {
                    AppMenu.Quit();
                }
                else 
                {
                    Application.RequestStop();
                }
                return true;
            }

            return base.ProcessKey(keyEvent);
        }

        public abstract MenuBarItem[] Menu { get; }

        protected void Open<TWindow>()
            where TWindow : BaseFullScreenWindow
        {
            ScreenManager.ShowFullScreen<TWindow>();
        }

        protected void Load(Action job)
        {
            ScreenManager.ShowLoadingDialog(job);
        }

        protected void Load(Task job)
        {
            ScreenManager.ShowLoadingDialog(job);
        }

        protected TResult Load<TResult>(Func<TResult> job)
        {
            return ScreenManager.ShowLoadingDialog(job);
        }

        protected TResult Load<TResult>(Task<TResult> job)
        {
            return ScreenManager.ShowLoadingDialog(job);
        }
    }
}