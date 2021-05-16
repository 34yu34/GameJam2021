using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSeek : AiState
{
    public override int StateId => 1;

    private Timestamp _timestamp;

    public override void Act()
    {
        if(_timestamp == null || _timestamp.HasPassed())
        {
            _timestamp = Timestamp.In(2f);
            NavMeshAgent.SetDestination(EnemyBehaviour.Player.transform.position);
        }
    }

    public override AiState NextState()
    {
        var distance = Vector3.Distance(transform.position, EnemyBehaviour.Player.transform.position);
        if (distance < EnemyBehaviour.ShotDistance)
        {
            return GetState<AIShootingState>();
        }

        return this;
    }
}
