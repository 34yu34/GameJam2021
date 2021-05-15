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

};