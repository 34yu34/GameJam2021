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
    private GameObject _player;

    enum State { Calm, Chase };

    private State _state = State.Calm;

    void FixedUpdate()
    {
        change_state();
        Debug.Log(_state);
        switch (_state)
        {
            case State.Calm:
                NavMeshAgent.ResetPath();
                break;
            case State.Chase:
                NavMeshAgent.SetDestination(_player.transform.position);
                break;
            default:
                break;
        }

    }

    private void change_state()
    {
        switch (_state)
        {
            case State.Calm:
                if (sees_player())
                {
                    _state = State.Chase;
                }
                break;
            case State.Chase:
                if (is_far_from_player())
                {
                    _state = State.Calm;
                }
                break;
            default:
                _state = State.Calm;
                break;
            

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


        return Vector3.Angle(transform.forward, _player.transform.position - transform.position) < 181 &&
            hit.collider.gameObject == _player;
    }

    private bool is_far_from_player()
    {
        return Vector3.Distance(transform.position, _player.transform.position) > _stop_distance;
    }
}
