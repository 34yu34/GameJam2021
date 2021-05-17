using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class SolarStormEvent : Event
    {
        public override bool IsMajor => false;

        public override string SoundName => "SolarStorm";
        public override string Name => "SolarStorm";

        public override void DoEvent()
        {
            Debug.Log($"{this.GetType().Name}WEIGHT: [{this.ProbabilityWeight}]");
        }

        public override void UndoEvent()
        {
            
        }

        public override bool CanHappen() => true;
        public override void ResetEvent() { }
    }
}
