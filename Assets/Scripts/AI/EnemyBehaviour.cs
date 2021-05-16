using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Damageable))]
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
    private float _shot_distance;
    public float ShotDistance => _shot_distance;

    [SerializeField]
    private float _shot_cooldown;
    public float ShotCooldown => _shot_cooldown;


    [SerializeField]
    private GameObject _player;

    public GameObject Player => _player;

    private AiState _aiState;
    public AiState CurrentAiState => _aiState;

    private Damageable _damageable_component;


    private void Start()
    {
        _player = GameObject.Find("Player");
        _aiState = gameObject.AddComponent<AiCalmState>();
        add_death_listener();
    }

    private void FixedUpdate()
    {
        _aiState.Act();
        _aiState = _aiState.NextState();
    }

    private void add_death_listener()
    {
        _damageable_component = GetComponent<Damageable>();
        _damageable_component.OnDeath.AddListener(death);
    }

    private void death()
    {
        _aiState = GetComponent<AiDeathState>() ?? gameObject.AddComponent<AiDeathState>();
        Debug.Log("Dead behavior");

    }
}
