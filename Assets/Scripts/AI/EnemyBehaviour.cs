using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    private float _roam_distance;
    public float RoamDistance => _roam_distance;

    [SerializeField]
    private float _roam_time;
    public float RoamTime => _roam_time;

    [SerializeField]
    private bool _seeking = true;
    public bool Seeking => _seeking;


    private Player _player;
    public GameObject Player => (_player ??= FindObjectOfType<Player>()).gameObject;

    private AiState _aiState;
    public AiState CurrentAiState => _aiState;

    private Damageable _damageable_component;

    private bool _is_dead;


    private void Start()
    {
        if (_seeking)
        {
            _aiState = gameObject.AddComponent<AiSeek>();
        }
        else
        {
            _aiState = gameObject.AddComponent<AiCalmState>();
        }
        _is_dead = false;
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
        if (_is_dead)
        {
            return;
        }

        _aiState = GetComponent<AiDeathState>() ?? gameObject.AddComponent<AiDeathState>();
        _is_dead = true;
    }
}
