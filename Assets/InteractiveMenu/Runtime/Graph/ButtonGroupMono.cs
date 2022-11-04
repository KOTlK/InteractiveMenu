using System;
using InteractiveMenu.Buttons;
using InteractiveMenu.Runtime.Input;
using UnityEngine;

namespace InteractiveMenu.Runtime.Graph
{
    public class ButtonGroupMono : MonoBehaviour, IButtonGroup
    {
        [SerializeField] private Button[] _buttons = null;
        [SerializeField] private KeyboardInput _input = null;
        
        private IButtonGroup _buttonGroup;

        private void Start()
        {
            _buttonGroup = new ButtonGroup(_buttons, _input);
        }

        private void OnDestroy()
        {
            Dispose();
        }

        public void Dispose() => _buttonGroup.Dispose();

        public void Write(IButton button) => _buttonGroup.Write(button);

        public void SelectNext(Side side) => _buttonGroup.SelectNext(side);

        public void Click() => _buttonGroup.Click();
    }
}