using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public void MoveObjectOnFixedUpdate(Vector3 direction, float linear_speed)
    {
        transform.position += direction * linear_speed * Time.fixedDeltaTime;
    }
}
