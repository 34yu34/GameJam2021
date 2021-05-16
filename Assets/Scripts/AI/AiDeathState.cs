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
            _timestamp = Timestamp.In(5f);
            NavMeshAgent.ResetPath();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        if (_timestamp.HasPassed())
        {
            Destroy(this.gameObject);
        }

    }

}
