using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class SolarStormEvent : Event
    {
        public bool IsMajor => false;

        public int DurationInSeconds => 60;

        public override void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name}WEIGHT: [{this.ProbabilityWeight}]");
        }

        public override void UndoEvent(EventEngineConstructorFacade engineConstructorFacade)
        {
            
        }

        public override bool CanHappen() => true;
    }
}
