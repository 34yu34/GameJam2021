using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent _nav_mesh_agent;
    protected NavMeshAgent NavMeshAgent => _nav_mesh_agent ??= GetComponent<NavMeshAgent>();

    [SerializeField] 
    private float _follow_up_distance;

    [SerializeField]
    private float _stop_distance;

    [SerializeField] 
    private float _vision_angle;

    [SerializeField]
    private GameObject _player;

    public enum AiState { Calm = 0, Chase = 1};

    private AiState _aiState;
    public AiState CurrentAiState => _aiState;

    void FixedUpdate()
    {
        change_state();
        switch (_aiState)
        {
            case AiState.Calm:
                NavMeshAgent.ResetPath();
                break;
            case AiState.Chase:
                NavMeshAgent.SetDestination(_player.transform.position);
                break;
            default:
                break;
        }

    }

    private void change_state()
    {
        switch (_aiState)
        {
            case AiState.Calm:
                if (sees_player())
                {
                    _aiState = AiState.Chase;
                }

                return;
            case AiState.Chase:
                if (is_far_from_player())
                {
                    _aiState = AiState.Calm;
                }

                return;
            default:
                _aiState = AiState.Calm;
                return;
            

        }
    }

    private bool sees_player()
    {
        RaycastHit hit;
        var begin = transform.position;
        begin.y = _player.transform.position.y;

        if (!Physics.Raycast(begin, _player.transform.position - begin, out hit, _follow_up_distance))
        {
            return false;
        }


        return Vector3.Angle(transform.forward, _player.transform.position - transform.position) < _vision_angle &&
            hit.collider.gameObject == _player;
    }

    private bool is_far_from_player()
    {
        return Vector3.Distance(transform.position, _player.transform.position) > _stop_distance;
    }
}
