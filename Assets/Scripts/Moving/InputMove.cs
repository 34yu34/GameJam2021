using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Jump))]
public class InputMove : MonoBehaviour
{
    private Move _move_component;

    private Jump _jump_component;

    private float _speed;

    [SerializeField]
    private float _sprint_speed = 2;

    [SerializeField]
    private float _normal_speed = 1;

    [SerializeField]
    private float _time_to_sprint_speed = 0.5f;

    private float _sprint_accel;

    private Vector3 _direction;

    private void Awake()
    {
        set_acceleration();
    }

    private void set_acceleration()
    {
        _sprint_accel = (_sprint_speed - _normal_speed) / _time_to_sprint_speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        get_required_components();
    }

    private void get_required_components()
    {
        _move_component = GetComponent<Move>();
        _jump_component = GetComponent<Jump>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move_over_input();
    }

    private void move_over_input()
    {
        set_direction();

        set_speed();

        _move_component.MoveObjectOnFixedUpdate(_direction, _speed);
    }

    private void set_direction()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        _direction = transform.right * horizontalInput + transform.forward * verticalInput;
    }

    private void Update()
    {
        check_jump();
    }

    private void check_jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jump_component.JumpObject();
        }
    }

    private void set_speed()
    {

        if (Input.GetButton("Sprint"))
        {
            if(_speed < _sprint_speed)
            {
                _speed += _sprint_accel * Time.fixedDeltaTime;
                _speed = Mathf.Clamp(_speed, 0f, _sprint_speed);
            }
        }
        else
        {
            _speed = _normal_speed;
        }
    }
}
