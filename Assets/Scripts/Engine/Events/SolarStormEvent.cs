using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class SolarStormEvent : IEvent
    {
        public bool IsMajor => false;

        public int ProbabilityWeight { get; set; }

        public void DoEvent()
        {
            Debug.Log($"{this.GetType().Name} WEIGHT: [{this.ProbabilityWeight}]");
        }

        public bool CanHappen() => true;
    }
}
