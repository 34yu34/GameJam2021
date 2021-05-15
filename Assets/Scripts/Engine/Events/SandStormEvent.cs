using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    [System.Serializable]
    public class /*Darude*/SandStormEvent : Event
    {
        [SerializeField]
        private Material _sandstorm_shader;

        public bool IsMajor => false;

        public override void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} on DoEvent");
            var player = eventEngineConstructorFacade.Player;

            player.GetComponent<Move>().SetSlowSpeed();

            Camera.main.GetComponent<CameraRenderer>().FadeIn(_sandstorm_shader);
        }

        public override void UndoEvent(EventEngineConstructorFacade eventEngineConstructorFacade)
        {
            Debug.Log($"{this.GetType().Name} on UndoEvent");
            var player = eventEngineConstructorFacade.Player;

            player.GetComponent<Move>().SetNormalSpeed();
            
            Camera.main.GetComponent<CameraRenderer>().FadeOut();

        }

        public override bool CanHappen() => true;
    }
}
