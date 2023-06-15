using UnityEngine;

namespace Source.Car
{
    public sealed class WheelView : MonoBehaviour
    {
        public void SetTransform(WheelCollider wheelCollider)
        {
            wheelCollider.GetWorldPose(out var position, out var rotation);

            transform.position = position;
            transform.rotation = rotation;
        }
    }
}