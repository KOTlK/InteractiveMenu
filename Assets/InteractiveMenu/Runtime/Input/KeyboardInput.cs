using System;
using InteractiveMenu.Runtime.Graph;
using UnityEngine;

namespace InteractiveMenu.Runtime.Input
{
    public class KeyboardInput : MonoBehaviour, IInputScheme
    {
        public event Action<Side> MoveButtonPressed = delegate {  };
        public event Action InteractButtonPressed = delegate {  };

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                MoveButtonPressed.Invoke(Side.Up);

            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                MoveButtonPressed.Invoke(Side.Down);

            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                MoveButtonPressed.Invoke(Side.Left);

            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                MoveButtonPressed.Invoke(Side.Right);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                InteractButtonPressed.Invoke();
        }
    }
}