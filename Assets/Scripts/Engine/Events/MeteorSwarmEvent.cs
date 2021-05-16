using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Engine.Events
{
    public class MeteorSwarmEvent : Event
    {
        [SerializeField]
        private Material _meteorswarm_shader;

        public override bool IsMajor => false;

        public override string SoundName => "MeteorSwarm";
        
        public override void DoEvent()
        {
            Camera.main.GetComponent<CameraRenderer>().FadeIn(_meteorswarm_shader);
        }

        public override void UndoEvent()
        {
            Camera.main.GetComponent<CameraRenderer>().FadeIn(_meteorswarm_shader);
        }

        public override bool CanHappen() => true;

        public override void ResetEvent() { }
    }
}
