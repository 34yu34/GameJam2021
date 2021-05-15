using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private float _ang_front;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        apply_rotation_over_mouse_input();
        limit_vertical_view_angle();
    }

    private void limit_vertical_view_angle()
    {
        _ang_front = Vector3.Angle(transform.forward, cam.transform.forward);
        bool is_looking_up = Vector3.Angle(transform.up, cam.transform.forward) < 90f;
        if (_ang_front > 90f)
        {
            rotate_to_limit(is_looking_up);
        }
    }

    private void rotate_to_limit(bool is_looking_up)
    {
        float correction = 90 - _ang_front;
        correction = is_looking_up ? -correction : correction;
        cam.transform.Rotate(Vector3.right, correction, Space.Self);
    }

    private void apply_rotation_over_mouse_input()
    {
        Vector2 _mouse_input = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, _mouse_input.x, Space.World);
        cam.transform.Rotate(Vector3.right, _mouse_input.y, Space.Self);
    }
}
