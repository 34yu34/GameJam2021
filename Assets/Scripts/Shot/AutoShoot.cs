using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    private ShotComponent _shooter;
    private ShotComponent Shooter => _shooter ??= GetComponent<ShotComponent>();

    private Timestamp next_shoot_timestamp;
    // Start is called before the first frame update
    void Start()
    {
        reset_next_shoot_timestamp();
    }

    private void reset_next_shoot_timestamp()
    {
        next_shoot_timestamp = Timestamp.In(1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(next_shoot_timestamp.IsAfter())
        {
            Shooter.SetShoot();
            reset_next_shoot_timestamp();
        }
    }
}
