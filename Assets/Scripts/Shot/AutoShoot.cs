using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    private ShotComponent _shooter;
    private ShotComponent Shooter => _shooter ??= GetComponent<ShotComponent>();

    private Timestamp next_shoot_timestamp;

    void Start()
    {
        reset_next_shoot_timestamp();
    }

    private void reset_next_shoot_timestamp()
    {
        next_shoot_timestamp = Timestamp.In(1f);
    }

    void FixedUpdate()
    {
        if (!next_shoot_timestamp.HasPassed()) return;
        
        Shooter.SetShoot();
        reset_next_shoot_timestamp();
    }
}
