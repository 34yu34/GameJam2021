using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingState : AiState
{

    private ShotComponent _shooter;
    public ShotComponent Shooter => _shooter ??= GetComponentInChildren<ShotComponent>();

    public Timestamp _next_shooting_timestamp;

    public override int StateId => 3;

    private void Start()
    {
        _next_shooting_timestamp = Timestamp.Back(10);
    }

    public override AiState NextState()
    {
        if (!_next_shooting_timestamp.HasPassed())
        {
            return this;
        }

        if (EnemyBehaviour.Seeking)
        {
            return GetState<AiSeek>();
        }

        return GetState<AiChaseState>();
    }

    public override void Act()
    {
        NavMeshAgent.ResetPath();

        if (_next_shooting_timestamp.HasPassed() && Vector3.Distance(EnemyBehaviour.Player.transform.position, transform.position) < EnemyBehaviour.ShotDistance)
        {
            transform.LookAt(EnemyBehaviour.Player.transform.position);
            Shooter.SetShoot();
            _next_shooting_timestamp = Timestamp.In(EnemyBehaviour.ShotCooldown);
        }

    }
}
