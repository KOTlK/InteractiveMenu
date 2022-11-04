using System;
using InteractiveMenu.Buttons;

namespace InteractiveMenu.Runtime.Graph
{
    public interface IButtonGroup : IDisposable
    {
        void Write(IButton button);
        void SelectNext(Side side);
        void Click();
    }
}