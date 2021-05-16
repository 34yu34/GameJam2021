using UnityEngine;

public class LavaMove : MonoBehaviour
{
    private bool _is_moving = false;
    
    private float _moving_speed;

    private float _target_height;

    private void FixedUpdate()
    {
        if (!_is_moving) return;

        if (transform.position.y >= _target_height)
        {
            _is_moving = false;
            return;
        }

        transform.Translate(0, _moving_speed * Time.fixedDeltaTime, 0);
    }

    public void MoveUpwardsFor(float height, float duration)
    {
        _moving_speed = height / duration;
        _is_moving = true;
        _target_height = transform.position.y + height;
    }
}
