using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    [System.Serializable]
    public class /*Darude*/SandStormEvent : IEvent
    {
        [SerializeField]
        private Material _sandstorm_shader;

        public bool IsMajor => false;

        public int ProbabilityWeight { get; set; }

        public int? DurationInSeconds => 2;

        public void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} on DoEvent");
            var player = eventEngineConstructorFacade.Player;

            player.GetComponent<Move>().SetSlowSpeed();

            Camera.main.GetComponent<CameraRenderer>().ShaderMat = _sandstorm_shader;
        }

        public void UndoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} on UndoEvent");
            var player = eventEngineConstructorFacade.Player;

            player.GetComponent<Move>().SetNormalSpeed();
            
            Camera.main.GetComponent<CameraRenderer>().ShaderMat = null;

        }

        public bool CanHappen() => true;
    }
}
