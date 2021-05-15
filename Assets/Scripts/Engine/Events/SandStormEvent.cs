using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    [System.Serializable]
    public class /*Darude*/SandStormEvent : Event
    {
        [SerializeField]
        private Material _sandstorm_shader;

        public override bool IsMajor => false;

        public override void DoEvent()
        {
            Debug.Log($"{this.GetType().Name} on DoEvent");
            var player = FindObjectOfType<Player>();

            player.GetComponent<Move>().SetSlowSpeed();

            Camera.main.GetComponent<CameraRenderer>().FadeIn(_sandstorm_shader);
        }

        public override void UndoEvent()
        {
            Debug.Log($"{this.GetType().Name} on UndoEvent");
            var player = FindObjectOfType<Player>();

            player.GetComponent<Move>().SetNormalSpeed();
            
            Camera.main.GetComponent<CameraRenderer>().FadeOut();
        }

        public override bool CanHappen() => true;
    }
}
