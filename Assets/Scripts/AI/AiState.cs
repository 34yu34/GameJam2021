using UnityEngine;
using UnityEngine.AI;

public abstract class AiState : MonoBehaviour
{
    public abstract int StateId { get; }

    private NavMeshAgent _nav_mesh_agent;
    protected NavMeshAgent NavMeshAgent => _nav_mesh_agent ??= GetComponent<NavMeshAgent>();

    private EnemyBehaviour _enemy_behaviour;
    protected EnemyBehaviour EnemyBehaviour => _enemy_behaviour ??= GetComponent<EnemyBehaviour>();

    public abstract AiState NextState();

    public abstract void Act();

    public AiState GetState<T>() where T : AiState
    {
        return GetComponent<T>() ?? gameObject.AddComponent<T>();
    }

    protected bool sees_player()
    {
        var begin = find_begining_ray();

        if (Vector3.Angle(transform.forward, EnemyBehaviour.Player.transform.position - transform.position) > EnemyBehaviour.VisionAngle ||
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

    protected Vector3 find_begining_ray()
    {
        var begin = transform.position;
        begin.y = EnemyBehaviour.Player.transform.position.y;
        return begin;
    }

};