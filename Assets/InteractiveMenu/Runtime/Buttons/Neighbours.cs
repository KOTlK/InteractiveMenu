using System;
using System.Collections.Generic;
using InteractiveMenu.Runtime.Graph;
using UnityEngine;

namespace InteractiveMenu.Buttons
{
    [Serializable]
    public class Neighbours
    {
        [SerializeField] private Button _left;
        [SerializeField] private Button _right;
        [SerializeField] private Button _up;
        [SerializeField] private Button _down;

        public Dictionary<Side, IButton> Get()
        {
            var dict = new Dictionary<Side, IButton>();

            if (_left != null)
                dict.Add(Side.Left, _left);

            if (_right != null)
                dict.Add(Side.Right, _right);
            
            if (_up != null)
                dict.Add(Side.Up, _up);
            
            if (_down != null)
                dict.Add(Side.Down, _down);

            return dict;
        }
    }
}