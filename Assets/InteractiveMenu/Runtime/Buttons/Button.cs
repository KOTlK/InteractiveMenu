using System;
using System.Collections.Generic;
using InteractiveMenu.Runtime.Graph;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InteractiveMenu.Buttons
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class Button : 
        MonoBehaviour, 
        IButton,
        IPointerClickHandler, 
        IPointerEnterHandler, 
        IPointerExitHandler, 
        IPointerDownHandler, 
        IPointerUpHandler
    {
        [SerializeField] private Neighbours _neighbourButtons;
        [SerializeField] private Sprite _backGround = null;
        [SerializeField] private TMP_Text _text = null;
        [SerializeField] private Color _selectedColor, _selectedTextColor = Color.gray;
        [SerializeField] private Color _deselectedColor, _deselectedTextColor = Color.white;
        
        private Image _image;
        private Dictionary<Side, IButton> _neighbours;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.sprite = _backGround;
            _neighbours = _neighbourButtons.Get();
        }

        private void OnValidate()
        {
            var image = GetComponent<Image>();
            image.sprite = _backGround;
            _text.color = _deselectedTextColor;
            image.color = _deselectedColor;
            
        }

        public event Action Clicked = delegate {  };
        public event Action<IButton> Selected = delegate {  };
        
        public bool IsClicked { get; private set; }

        public void Select()
        {
            Selected.Invoke(this);
            _image.color = _selectedColor;
            _text.color = _selectedTextColor;
        }

        public void Deselect()
        {
            _image.color = _deselectedColor;
            _text.color = _deselectedTextColor;
        }

        public void Click()
        {
            IsClicked = true;
            Select();
            Clicked.Invoke();
            Release();
            Deselect();
        }

        public void Release()
        {
            if (IsClicked)
                IsClicked = false;
        }

        public void OnPointerClick(PointerEventData eventData) => Click();

        public void OnPointerEnter(PointerEventData eventData) => Select();

        public void OnPointerExit(PointerEventData eventData) => Deselect();

        public void OnPointerDown(PointerEventData eventData) => Select();

        public void OnPointerUp(PointerEventData eventData) => Click();
        
        public bool HasNeighbour(Side side) => _neighbours.ContainsKey(side);
        public IButton GetNeighbour(Side side) => _neighbours[side];
    }
}