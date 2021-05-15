using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public float ang_front;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _mouse_input = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, _mouse_input.x, Space.World);
        cam.transform.Rotate(Vector3.right, _mouse_input.y, Space.Self);

        ang_front = Vector3.Angle(transform.forward, cam.transform.forward);
        bool is_looking_up = Vector3.Angle(transform.up, cam.transform.forward) < 90f;
        if(ang_front > 90f)
        {
            float correction = 90 - ang_front;
            correction = is_looking_up ? -correction : correction;
            cam.transform.Rotate(Vector3.right, correction, Space.Self);
        }
    }
}
