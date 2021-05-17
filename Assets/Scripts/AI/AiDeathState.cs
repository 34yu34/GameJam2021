using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
 
    public override int StateId => 2;

    private Timestamp _timestamp;

    private Timestamp _spawn_timestamp;

    public override AiState NextState()
    {
        return this;
    }

    public override void Act()
    {
        if (_timestamp == null)
        {
            _timestamp = Timestamp.In(5f);
            _spawn_timestamp = Timestamp.In(2);
            NavMeshAgent.ResetPath();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            Destroy(gameObject.GetComponent<Targetable>());
            Destroy(gameObject.GetComponent<Collider>());

            AkSoundEngine.PostEvent("Robot_Die", gameObject);

            var killCounter = GameObject.Find("KillCounter").GetComponent<KillCount>();
            if (killCounter != null) killCounter.AddKill();
        }

        if (_spawn_timestamp.HasPassed())
        {
            _spawn_timestamp = Timestamp.In(5f);
            SpawnManager.Instance.TrySpawnObject(transform.position);
        }

        if (_timestamp.HasPassed())
        {
            Destroy(this.gameObject);
        }
    }
}
