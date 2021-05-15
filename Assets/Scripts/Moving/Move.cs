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

    private float _current_speed;

    private float _accel;


    [SerializeField]
    private float _time_to_sprint_speed = 0.5f;

    public Vector3 Direction { get; set; }

    private void set_acceleration()
    {
        _accel = (_sprint_speed - _normal_speed) / _time_to_sprint_speed;
    }

    public void SetSprint()
    {
        _current_speed = _sprint_speed;
        if (_current_speed < _sprint_speed)
        {
            _current_speed += _accel * Time.fixedDeltaTime;
            _current_speed = Mathf.Clamp(_current_speed, 0f, _sprint_speed);
        }
    }

    public void SetWalk()
    {
        _current_speed = _normal_speed;
    }

    private void FixedUpdate()
    {
        transform.position += Direction * _current_speed * Time.fixedDeltaTime;
    }
}
