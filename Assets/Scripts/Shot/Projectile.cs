using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Projectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody ??= GetComponent<Rigidbody>();

    private Vector3 _direction_vector;
    public Vector3 DirectionVector => _direction_vector;

    [SerializeField]
    private float _speed;
    public float Speed => _speed;

    [SerializeField]
    private int _damage;
    public int Damage => _damage;

    private void Start()
    {
       this.Rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        this.Rigidbody.velocity = _direction_vector * this.Speed;
        this.transform.LookAt(transform.position + _direction_vector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var targetable = collision.rigidbody?.GetComponent<Targetable>();

        if (targetable == null) return;

        var contactPoint = collision.GetContact(0).point;

        targetable.Hit(
            new HitInfoDto
            {
                Damage = Damage,
                HitPosition = contactPoint,
                Origin = contactPoint - this.DirectionVector
            }
        );

        Destroy(gameObject);
    }

    public void Launch(Vector3 direction_vector, int damage)
    {
        _direction_vector = direction_vector;
        _damage = damage;

        Destroy(gameObject, 1.0f);
    }
}
