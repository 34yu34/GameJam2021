using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 Speed { get; set; }

    private float _hit_in;
    public float HitIn => _hit_in;


    private void FixedUpdate()
    {
        transform.position += Speed;
    }

    public void Launch(Vector3 direction_vector, Vector3 TargetPos)
    {
        Speed = direction_vector * _speed;

        _hit_in = (transform.position - TargetPos).magnitude / _speed;

        Destroy(gameObject, _hit_in);
    }
}
