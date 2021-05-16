using UnityEngine;

public class AiRoam : AiState
{
    public override int StateId => 1;

    private bool _first = true;

    private Timestamp _timestamp;

    public override void Act()
    {
        if (_first)
        {
            set_random_path();
            _first = false;
            _timestamp = Timestamp.In(EnemyBehaviour.RoamTime);
        }
    }

    public override AiState NextState()
    {
        if(navmesh_done() || _timestamp.HasPassed())
        {
            _first = true;
            return GetState<AiCalmState>();
        }

        if (sees_player())
        {
            _first = true;
            return GetState<AiChaseState>(); ;
        }

        return this;
    }

    private bool navmesh_done()
    {
        // Check if we've reached the destination
        if (!NavMeshAgent.pathPending)
        {
            if (NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
            {
                if (!NavMeshAgent.hasPath || NavMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void set_random_path()
    {
        var direction = new Vector3(Random.Range(-1, 1), transform.position.y, Random.Range(-1, 1));
        direction.Normalize();

        var newPos = gameObject.transform.position + direction * EnemyBehaviour.RoamDistance;

        NavMeshAgent.SetDestination(newPos);
    }

}
