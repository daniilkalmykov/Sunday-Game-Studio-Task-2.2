using UnityEngine;

namespace Source.Car
{
    public sealed class Wheel
    {
        private const float BreakTorque = 500;
        
        private readonly WheelPosition _wheelPosition;
        private readonly WheelCollider _wheelCollider;

        public Wheel(WheelPosition wheelPosition, WheelCollider wheelCollider)
        {
            _wheelPosition = wheelPosition;
            _wheelCollider = wheelCollider;
        }

        public void SetMotorTorque(float motorTorque)
        {
            _wheelCollider.brakeTorque = 0;
            
            if (_wheelPosition == WheelPosition.Front)
                _wheelCollider.motorTorque = motorTorque;
        }

        public void SetStreetAngle(float angle)
        {
            if (_wheelPosition == WheelPosition.Front)
                _wheelCollider.steerAngle = angle;
        }

        public void ResetOptions()
        {
            _wheelCollider.brakeTorque = BreakTorque;
        }
    }
}