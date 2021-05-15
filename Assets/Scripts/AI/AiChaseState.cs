using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChaseState : AiState
{
    public override int StateId => 1;
    public override AiState NextState()
    {
        if (is_far_from_player())
        {
            return GetState<AiCalmState>();
        }

        return this;
    }

    public override void Act()
    {
        NavMeshAgent.SetDestination(EnemyBehaviour.Player.transform.position);
    }

    private bool is_far_from_player()
    {
        return Vector3.Distance(transform.position, EnemyBehaviour.Player.transform.position) > EnemyBehaviour.StopDistance;
    }
}
