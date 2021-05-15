using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _nav_mesh_agent;

    [SerializeField]
    private Transform _player;

    void Update()
    {
        _nav_mesh_agent.SetDestination(_player.position);
    }
}
