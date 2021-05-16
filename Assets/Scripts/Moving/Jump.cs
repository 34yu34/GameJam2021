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
    public Rigidbody Rb => _rb ??= GetComponent<Rigidbody>();

    public void SetJump()
    {
        ShouldJump = true;
    }

    private void TryJump()
    {
        ShouldJump = false;

        if (!Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, out _, 0.5f))
        {
            return;
        }

        var vel = Rb.velocity;
        vel.y = _jump_speed;
        Rb.velocity = vel;
    }

    public void FixedUpdate()
    {
        if (ShouldJump)
        {
            TryJump();
        }
    }
}
