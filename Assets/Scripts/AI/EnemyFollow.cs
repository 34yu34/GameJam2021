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

    private AiState _aiState;
    public AiState CurrentAiState => _aiState;

    void FixedUpdate()
    {
        change_state();
        act();
    }

    private void act()
    {
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
                _aiState = calm_state_change();
                return;

            case AiState.Chase:
                _aiState = chase_state_change();
                return;

            default:
                _aiState = AiState.Calm;
                return;
        }
    }

    private AiState chase_state_change()
    {
        if (is_far_from_player())
        {
            return AiState.Calm;
        }

        return _aiState;
    }

    private AiState calm_state_change()
    {
        if (sees_player())
        {
            return AiState.Chase;
        }

        return _aiState;
    }

    private bool sees_player()
    {
        var begin = find_begining_ray();

        if (!Physics.Raycast(begin, _player.transform.position - begin,out var hit, _follow_up_distance))
        {
            return false;
        }

        return Vector3.Angle(transform.forward, _player.transform.position - transform.position) < _vision_angle &&
            hit.collider.gameObject == _player;
    }

    private Vector3 find_begining_ray()
    {
        var begin = transform.position;
        begin.y = _player.transform.position.y;
        return begin;
    }

    private bool is_far_from_player()
    {
        return Vector3.Distance(transform.position, _player.transform.position) > _stop_distance;
    }
}
