using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Jump))]
public class InputMove : MonoBehaviour
{
    private Move _move_component;

    private Jump _jump_component;

    void Start()
    {
        get_required_components();
    }

    private void get_required_components()
    {
        _move_component = GetComponent<Move>();
        _jump_component = GetComponent<Jump>();
    }

    private void Update()
    {
        move_over_input();
        check_jump();
    }

    private void move_over_input()
    {
        set_direction();

        set_speed();
    }

    private void set_direction()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _move_component.Direction = transform.right * horizontalInput + transform.forward * verticalInput;
    }

    private void check_jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jump_component.SetJump();
        }
    }

    private void set_speed()
    {
        if (Input.GetButton("Sprint"))
        {
            _move_component.SetSprint();
            return;
        }
        
        _move_component.SetWalk();
    }
}
