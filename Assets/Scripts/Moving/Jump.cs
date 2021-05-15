using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void JumpObject(float jumpspeed = 5)
    {
        var vel = _rb.velocity;
        vel.y = jumpspeed;
        _rb.velocity = vel;
    }
}
