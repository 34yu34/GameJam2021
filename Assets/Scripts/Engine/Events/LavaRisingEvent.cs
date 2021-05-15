﻿using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class LavaRisingEvent : Event
    {
        public bool IsMajor => true;

        public int DurationInSeconds => -1;

        public override void  DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} WEIGHT: [{this.ProbabilityWeight}]");
        }

        public override void UndoEvent(EventEngineConstructorFacade engineConstructorFacade) { }

        public override bool CanHappen() => true;
    }
}
