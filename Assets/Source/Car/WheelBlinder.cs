using UnityEngine;

namespace Source.Car
{
    [RequireComponent(typeof(WheelView))]
    public sealed class WheelBlinder : MonoBehaviour
    {
        [SerializeField] private WheelPosition _wheelPosition;

        [field: SerializeField] public WheelCollider WheelCollider { get; private set; }

        public WheelView WheelView { get; private set; }
        public Wheel Wheel { get; private set; }

        private void Awake()
        {
            WheelView = GetComponent<WheelView>();
        }

        private void Start()
        {
            Wheel = new Wheel(_wheelPosition, WheelCollider);
        }
    }
}