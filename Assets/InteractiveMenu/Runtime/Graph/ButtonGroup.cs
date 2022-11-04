using System.Collections.Generic;
using InteractiveMenu.Buttons;
using InteractiveMenu.Runtime.Input;

namespace InteractiveMenu.Runtime.Graph
{
    public class ButtonGroup : IButtonGroup
    {
        private readonly List<IButton> _buttons;
        private readonly IInputScheme _input;

        private IButton _selectedButton;

        public ButtonGroup(IEnumerable<IButton> buttons, IInputScheme input)
        {
            _buttons = new List<IButton>(buttons);
            _input = input;
            _selectedButton = _buttons[0];
            _selectedButton.Select();

            foreach (var button in _buttons)
            {
                button.Selected += SwitchSelectedButton;
            }
            
            _input.MoveButtonPressed += SelectNext;
            _input.InteractButtonPressed += Click;
        }

        public void Write(IButton button)
        {
            _buttons.Add(button);
            button.Selected += SwitchSelectedButton;
        }

        public void SelectNext(Side side)
        {
            if (!_selectedButton.HasNeighbour(side)) return;
            
            _selectedButton.Deselect();
            _selectedButton = _selectedButton.GetNeighbour(side);
            _selectedButton.Select();
        }

        public void Click() => _selectedButton.Click();

        public void Dispose()
        {
            _input.MoveButtonPressed -= SelectNext;
            _input.InteractButtonPressed -= _selectedButton.Click;
            
            foreach (var button in _buttons)
            {
                button.Selected -= SwitchSelectedButton;
            }
        }

        private void SwitchSelectedButton(IButton button)
        {
            _selectedButton.Deselect();
            _selectedButton = button;
        }
    }
}