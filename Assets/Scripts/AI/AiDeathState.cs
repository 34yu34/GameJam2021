using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    public override int StateId => 2;

    private Timestamp _timestamp;

    private void Start()
    {
    }

    public override AiState NextState()
    {
        return this;
    }

    public override void Act()
    {
        if (_timestamp == null)
        {
            Debug.Log("Kill act begin");

            _timestamp = Timestamp.In(5f);
            NavMeshAgent.ResetPath();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            var killCounter = GameObject.Find("KillCounter").GetComponent<KillCount>();
            if (killCounter != null) killCounter.AddKill();

            Debug.Log("Kill act");
        }

        if (_timestamp.HasPassed())
        {
            Destroy(this.gameObject);
        }

    }

}
