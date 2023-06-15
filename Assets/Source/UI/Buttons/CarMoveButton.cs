using Source.Car;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.UI.Buttons
{
    public sealed class CarMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Vector2Int _moveDirection;
        [SerializeField] private Vector2Int _rotateDirection;
        [SerializeField] private CarMovement _carMovement;
        
        private bool _isClicked;
        private float _clickingTime;
        private Vector2Int _startMoveDirection;
        private Vector2Int _startRotateDirection;

        private void Start()
        {
            _startMoveDirection = _moveDirection;
            _startRotateDirection = _rotateDirection;
            
            ResetDirections();
        }

        private void Update()
        {
            if (_isClicked == false)
                return;
            
            _clickingTime += Time.deltaTime;
            
            _carMovement.TryMove((Vector2)_moveDirection * _clickingTime);
            _carMovement.TryRotate(_rotateDirection);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isClicked = true;

            SetStartDirections();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isClicked = false;
            _clickingTime = 0;

            ResetDirections();
            _carMovement.TryResetMoveAndRotation();
        }

        private void ResetDirections()
        {
            SetDirections(Vector2Int.zero, Vector2Int.zero);
        }

        private void SetStartDirections()
        {
            SetDirections(_startMoveDirection, _startRotateDirection);
        }

        private void SetDirections(Vector2Int moveDirection, Vector2Int rotateDirection)
        {
            _moveDirection = moveDirection;
            _rotateDirection = rotateDirection;
        }
    }
}