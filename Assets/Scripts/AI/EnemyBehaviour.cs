using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent _nav_mesh_agent;
    protected NavMeshAgent NavMeshAgent => _nav_mesh_agent ??= GetComponent<NavMeshAgent>();

    [SerializeField] 
    private float _follow_up_distance;
    public float FollowUpDistance => _follow_up_distance;

    [SerializeField]
    private float _stop_distance;
    public float StopDistance => _stop_distance;

    [SerializeField] 
    private float _vision_angle;
    public float VisionAngle => _vision_angle;

    [SerializeField]
    private GameObject _player;

    public GameObject Player => _player;

    private AiState _aiState;
    public AiState CurrentAiState => _aiState;

    private void Start()
    {
        _aiState = gameObject.AddComponent<AiCalmState>();
    }

    private void FixedUpdate()
    {
        _aiState = _aiState.NextState();
        _aiState.Act();
    }


}
