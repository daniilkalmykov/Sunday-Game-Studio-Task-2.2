using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.UI.Buttons
{
    public sealed class CarMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isClicked;

        private void Update()
        {
            if (_isClicked)
                print("AAA");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isClicked = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isClicked = false;
        }
    }
}