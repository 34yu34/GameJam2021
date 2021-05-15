using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class LavaRisingEvent : IEvent
    {
        public bool IsMajor => true;

        public int ProbabilityWeight { get; set; }

        public int? DurationInSeconds => null;

        public void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} WEIGHT: [{this.ProbabilityWeight}]");
        }

        public void UndoEvent(EventEngineConstructorFacade engineConstructorFacade) { }

        public bool CanHappen() => true;
    }
}
