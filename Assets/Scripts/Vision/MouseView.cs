using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float _up_angle_limit = 80f;

    [SerializeField]
    private float _mouse_sensitivity = 3f;

    private float _ang_front;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        apply_rotation_over_mouse_input();
        limit_vertical_view_angle();
    }

    private void limit_vertical_view_angle()
    {
        _ang_front = Vector3.Angle(transform.forward, cam.transform.forward);
        var is_looking_up = Vector3.Angle(transform.up, cam.transform.forward) < _up_angle_limit;
        if (_ang_front > _up_angle_limit)
        {
            rotate_to_limit(is_looking_up);
        }
    }

    private void rotate_to_limit(bool is_looking_up)
    {
        var correction = _up_angle_limit - _ang_front;
        correction = is_looking_up ? -correction : correction;
        cam.transform.Rotate(Vector3.right, correction, Space.Self);
    }

    private void apply_rotation_over_mouse_input()
    {
        var _mouse_input = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * _mouse_sensitivity;
        transform.Rotate(Vector3.up, _mouse_input.x, Space.World);
        cam.transform.Rotate(Vector3.right, _mouse_input.y, Space.Self);
    }
}
