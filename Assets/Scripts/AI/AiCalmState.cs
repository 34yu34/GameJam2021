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
    
}
