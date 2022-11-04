using System;
using InteractiveMenu.Runtime.Graph;

namespace InteractiveMenu.Runtime.Input
{
    public interface IInputScheme
    {
        event Action<Side> MoveButtonPressed;
        event Action InteractButtonPressed;
    }
}