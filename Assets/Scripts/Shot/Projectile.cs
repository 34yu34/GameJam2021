using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 Speed { get; set; }

    private float _hit_in_time;
    public float HitInTime => _hit_in_time;


    private void FixedUpdate()
    {
        transform.position += Speed * Time.deltaTime;
    }

    public void Launch(Vector3 direction_vector, Vector3 target_pos)
    {
        Speed = direction_vector * _speed;

        _hit_in_time = (transform.position - target_pos).magnitude / _speed;

        Destroy(gameObject, _hit_in_time);
    }
}
