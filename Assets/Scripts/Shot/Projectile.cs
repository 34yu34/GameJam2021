using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 Speed { get; set; }

    private float _time_until_hit;

    private void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime;
    }

    public void Launch(Vector3 direction_vector, Vector3 target_pos)
    {
        Speed = direction_vector * _speed;

        _time_until_hit = (transform.position - target_pos).magnitude / _speed;

        Destroy(gameObject, _time_until_hit);
    }
}
