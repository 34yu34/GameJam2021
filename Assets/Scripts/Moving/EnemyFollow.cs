using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _nav_mesh_agent;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Collider _collider_player;

    enum State { Calm, Chase };

    private State _state = State.Calm;

    void FixedUpdate()
    {
        change_state();
        Debug.Log(_state);
        switch (_state)
        {
            case State.Calm:
                _nav_mesh_agent.ResetPath();
                break;
            case State.Chase:
                _nav_mesh_agent.SetDestination(_player.transform.position);
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
        bool ray = Physics.Raycast(begin, _player.transform.position, out hit);
        Debug.Log(ray);
        //Debug.Break();
        return Vector3.Angle(transform.forward, _player.transform.position - transform.position) < 181 &&
            ray &&
            hit.collider == _collider_player;
    }

    private bool is_far_from_player()
    {
        return Vector3.Distance(transform.position, _player.transform.position) > 10f;
    }
}
