using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class LavaRisingEvent : IEvent
    {
        public bool IsMajor => true;

        public int ProbabilityWeight { get; set; }

        public void DoEvent()
        {
            Debug.Log($"{this.GetType().Name} WEIGHT: [{this.ProbabilityWeight}]");
        }

        public bool CanHappen() => true;
    }
}
