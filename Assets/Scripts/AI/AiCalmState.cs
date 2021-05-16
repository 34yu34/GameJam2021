using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCalmState : AiState
{
    public override int StateId => 0;
    public override AiState NextState()
    {
        if (sees_player())
        {
            return GetState<AiChaseState>(); ;
        }

        if (Random.Range(0, 300) == 0)
        {
            return GetState<AiRoam>();
        }

        return this;
    }

    public override void Act()
    {
        NavMeshAgent.ResetPath();
    }
    private bool sees_player()
    {
        var begin = find_begining_ray();

        if(Vector3.Angle(transform.forward, EnemyBehaviour.Player.transform.position - transform.position) > EnemyBehaviour.VisionAngle ||
            Vector2.Distance(transform.position, EnemyBehaviour.Player.transform.position) > EnemyBehaviour.FollowUpDistance)
        {
            return false;
        }

        if (!Physics.Raycast(begin, EnemyBehaviour.Player.transform.position - begin, out var hit, EnemyBehaviour.FollowUpDistance))
        {
            return false;
        }

        return hit.collider.gameObject == EnemyBehaviour.Player;
    }

    private Vector3 find_begining_ray()
    {
        var begin = transform.position;
        begin.y = EnemyBehaviour.Player.transform.position.y;
        return begin;
    }
}
