using System;
using UnityEngine;

namespace Source.Car
{
    public sealed class CarMovement : MonoBehaviour
    {
        [SerializeField] private WheelBlinder[] _wheelBlinders;
        [SerializeField] private float _force;
        [SerializeField] private float _maxAngle;

        private void Update()
        {
            foreach (var wheelBlinder in _wheelBlinders)
                wheelBlinder.WheelView.SetTransform(wheelBlinder.WheelCollider);
        }

        public void TryMove(Vector2 direction)
        {
            foreach (var wheelBlinder in _wheelBlinders)
            {
                if (wheelBlinder == null)
                    throw new ArgumentNullException();

                wheelBlinder.Wheel.SetMotorTorque(_force * direction.y);
            }
        }

        public void TryRotate(Vector2 direction)
        {
            foreach (var wheelBlinder in _wheelBlinders)
            {
                if (wheelBlinder == null)
                    throw new ArgumentNullException();

                wheelBlinder.Wheel.SetStreetAngle(_maxAngle * direction.x);
            }
        }

        public void TryResetMoveAndRotation()
        {
            foreach (var wheelBlinder in _wheelBlinders)
            {
                if (wheelBlinder == null)
                    throw new ArgumentNullException();

                wheelBlinder.Wheel.ResetOptions();
            }
        }
    }
}