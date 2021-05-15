using UnityEditor.Timeline.Actions;

namespace Assets.Scripts.Engine.Events
{
    public class /*Darude*/SandStormEvent : IEvent
    {
        public bool IsMajor => false;

        public int ProbabilityWeight { get; set; }

        public int? DurationInSeconds => 60;

        public void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            var player = eventEngineConstructorFacade.Player;

            player.GetComponent<Move>().SetSlowSpeed();
        }

        public void UndoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {

        }

        public bool CanHappen() => true;
    }
}
