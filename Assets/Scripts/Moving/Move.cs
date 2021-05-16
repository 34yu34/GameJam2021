using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(StaminaComponent))]
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

    private StaminaComponent _stamina;
    public StaminaComponent Stamina => _stamina ??= GetComponent<StaminaComponent>();


    [SerializeField]
    private float _time_to_sprint_speed = 0.5f;

    public Vector3 Direction { get; set; }

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
        if (!Stamina.TrySprint())
        {
            SetWalk();
            return;
        }

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

    private void FixedUpdate()
    {
        transform.position += Direction * _current_speed * Time.fixedDeltaTime;
    }
}
