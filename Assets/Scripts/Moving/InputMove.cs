using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class InputMove : MonoBehaviour
{
    private Move _move_component;

    private float _speed;

    [SerializeField]
    private float _sprint_speed = 2;

    [SerializeField]
    private float _normal_speed = 1;

    [SerializeField]
    private float _time_to_sprint_speed = 0.5f;

    private float _accel;

    private void Awake()
    {
        _accel = (_sprint_speed - _normal_speed) / _time_to_sprint_speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _move_component = GetComponent<Move>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;

        set_speed();

        _move_component.MoveObjectOnFixedUpdate(direction, _speed);
    }

    private void set_speed()
    {

        if (Input.GetButton("Sprint"))
        {
            if(_speed < _sprint_speed)
            {
                _speed += _accel * Time.fixedDeltaTime;
                _speed = Mathf.Clamp(_speed, 0f, _sprint_speed);
            }
        }
        else
        {
            _speed = _normal_speed;
        }
    }
}
