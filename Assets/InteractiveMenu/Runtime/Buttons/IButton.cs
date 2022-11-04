using System;
using InteractiveMenu.Runtime.Graph;

namespace InteractiveMenu.Buttons
{
    public interface IButton : IInteractiveObject, IButtonNode
    {
        event Action Clicked;
        event Action<IButton> Selected;
        bool IsClicked { get; }
        void Click();
        void Release();
    }
}