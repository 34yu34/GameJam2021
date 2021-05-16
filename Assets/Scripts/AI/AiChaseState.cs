using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChaseState : AiState
{
    public override int StateId => 1;
    public override AiState NextState()
    {
        return is_far_from_player();
    }

    public override void Act()
    {
        NavMeshAgent.SetDestination(EnemyBehaviour.Player.transform.position);
    }

    private AiState is_far_from_player()
    {
        var distance = Vector3.Distance(transform.position, EnemyBehaviour.Player.transform.position);

        if (distance > EnemyBehaviour.StopDistance)
        {
            return GetState<AiCalmState>();
        }

        if (distance < EnemyBehaviour.ShotDistance)
        {
            return GetState<AIShootingState>();
        }

        return this;
    }
}
