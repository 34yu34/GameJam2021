using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class InputMove : MonoBehaviour
{
    private Move _move_component;
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

        float speed = (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;

        _move_component.MoveObjectOnFixedUpdate(direction, speed);
    }
}
