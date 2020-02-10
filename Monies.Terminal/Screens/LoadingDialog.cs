using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Mono.Terminal;
using NStack;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public class LoadingDialog : Dialog
    {
        private readonly Label _lbl;

        private object _timeoutToken;
        private int _step;


        public LoadingDialog() : base("Loading...", 40, 9, new Button[0])
        {
            _lbl = new Label(12, 2, "Please wait");
            Add(_lbl);
        }

        public void Show(Action job)
        {
            Show(Task.Run(job));
        }

        public TResult Show<TResult>(Func<TResult> job)
        {
            return Show(Task.Run(job));
        }

        public void Show(Task job)
        {
            job.ContinueWith((_) => Application.MainLoop.Invoke(CloseLoading));

            _timeoutToken = Application.MainLoop.AddTimeout(new TimeSpan(0, 0, 0, 0, 300), RefreshLoader);
            Application.Run(this);

            if(job.Exception != null)
            {
                ScreenManager.ShowException(job.Exception);
                var logger = ServiceInjector.Logger<LoadingDialog>();
                logger.LogError(job.Exception, "Exception while executing background task!");
            }
        }

        public TResult Show<TResult>(Task<TResult> job)
        {
            job.ContinueWith((_) => Application.MainLoop.Invoke(CloseLoading));

            _timeoutToken = Application.MainLoop.AddTimeout(new TimeSpan(0, 0, 0, 0, 300), RefreshLoader);
            Application.Run(this);

            if(job.Exception != null)
            {
                ScreenManager.ShowException(job.Exception);
                var logger = ServiceInjector.Logger<LoadingDialog>();
                logger.LogError(job.Exception, "Exception while executing background task!");
            }

            return job.Result;
        }

        public override bool ProcessKey(KeyEvent kb)
        {
            return true;
        }

        private void CloseLoading()
        {
            Application.MainLoop.RemoveTimeout(_timeoutToken);
            Application.RequestStop();
        }

        private bool RefreshLoader(MainLoop loop)
        {
            var text = "Please wait";
            for(int i = 0; i < 4; i++)
            {
                if(i < _step)
                    text += ".";
                else
                    text += " ";
            }

            _lbl.Text = text;

            _step++;
            if(_step >= 4)
                _step = 0;

            return true;
        }
    }
}