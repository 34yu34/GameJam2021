using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private NavMeshAgent _nav_mesh_agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("IsWalking", !_nav_mesh_agent.isStopped);
    }
}
