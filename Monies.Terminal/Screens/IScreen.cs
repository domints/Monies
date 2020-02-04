using System;
using Terminal.Gui;

namespace Monies.Terminal.Screens
{
    public interface IScreen
    {
        MenuBarItem[] Menu { get; }
    }
}