using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private float _sprint_speed = 2;

    [SerializeField]
    private float _normal_speed = 1;

    [SerializeField]
    private float _slow_sprint_speed = 1f;

    [SerializeField]
    private float _slow_speed = 0.5f;

    private bool _is_slowed = false;

    private float _current_speed;

    private float _accel;


    [SerializeField]
    private float _time_to_sprint_speed = 0.5f;

    public Vector3 Direction { get; set; }


    [SerializeField]
    private float _walk_sfx_speed = 2f;

    private float _time_since_walk_sfx = Mathf.Infinity;

    public void Start()
    {
        set_acceleration();
    }

    private void set_acceleration()
    {
        _accel = (_sprint_speed - _normal_speed) / _time_to_sprint_speed;
    }

    public void SetSprint()
    {
        var current_sprint_speed = _is_slowed ? _slow_sprint_speed : _sprint_speed;

        if (_current_speed < current_sprint_speed)
        {
            _current_speed += _accel * Time.fixedDeltaTime;
            _current_speed = Mathf.Clamp(_current_speed, 0f, current_sprint_speed);
     
            return;
        }

        _current_speed = current_sprint_speed;
    }

    public void SetWalk()
    {
        _current_speed = (_is_slowed) ? _slow_speed : _normal_speed;
    }

    public void SetSlowSpeed()
    {
        _is_slowed = true;
    }

    public void SetNormalSpeed()
    {
        _is_slowed = false;
    }


    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > Mathf.Epsilon ||
            Input.GetAxisRaw("Vertical") > Mathf.Epsilon)
        {
            _time_since_walk_sfx += Time.deltaTime;

            if (_time_since_walk_sfx > (_walk_sfx_speed / _current_speed))
            {
                AkSoundEngine.PostEvent("Player_Walk", gameObject);
                _time_since_walk_sfx = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += Direction * _current_speed * Time.fixedDeltaTime;
    }
}
