using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class LavaRisingEvent : Event
    {
        public override bool IsMajor => true;

        public override void  DoEvent()
        {
            Debug.Log($"{this.GetType().Name} WEIGHT: [{this.ProbabilityWeight}]");
        }

        public override void UndoEvent() { }

        public override bool CanHappen() => true;
    }
}
