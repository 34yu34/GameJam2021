﻿using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class SolarStormEvent : IEvent
    {
        public bool IsMajor => false;

        public int ProbabilityWeight { get; set; }

        public int? DurationInSeconds => 60;

        public void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name}WEIGHT: [{this.ProbabilityWeight}]");
        }

        public void UndoEvent(EventEngineConstructorFacade engineConstructorFacade)
        {
            
        }

        public bool CanHappen() => true;
    }
}
