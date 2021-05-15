using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] 
    private float _jump_speed;

    private bool ShouldJump;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetJump()
    {
        ShouldJump = true;
    }

    private void TryJump()
    {
        ShouldJump = false;

        if (!Physics.Raycast(transform.position, -transform.up, out _, 0.1f))
        {
            return;
        }

        var vel = _rb.velocity;
        vel.y = _jump_speed;
        _rb.velocity = vel;
    }

    public void FixedUpdate()
    {
        if (ShouldJump)
        {
            TryJump();
        }
    }
}
