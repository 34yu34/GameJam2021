using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class LavaRisingEvent : Event
    {
        public override bool IsMajor => true;

        private int _event_occurrences;

        [SerializeField]
        private float _max_event_occurrences;

        [SerializeField]
        private float _lava_rising_duration = 5;

        [SerializeField]
        private float _height_increases = 0.1f;

        public override void DoEvent()
        {
            ++_event_occurrences;

            Camera.main.GetComponent<CameraRenderer>().ShakeCamera(2f, 0.05f);

            FindObjectOfType<LavaMove>().MoveUpwardsFor(_height_increases, _lava_rising_duration);
        }

        public override void UndoEvent() { }

        public override bool CanHappen() => _event_occurrences < _max_event_occurrences;
        public override void ResetEvent()
        {
            _event_occurrences = 0;
        }
    }
}
