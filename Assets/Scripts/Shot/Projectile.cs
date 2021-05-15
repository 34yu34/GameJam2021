using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody _rigid_body;
    public Rigidbody RigidBody => _rigid_body ??= GetComponent<Rigidbody>();

    private bool _is_launched = false;

    private Vector3 _direction_vector;
    public Vector3 DirectionVector
    {
        get => _direction_vector;
        set => _direction_vector = value;
    }

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _damage;
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public float Speed => _speed;

    private void OnCollisionEnter(Collision collision)
    {
        var targetable = collision.rigidbody.GetComponent<Targetable>();

        if (targetable == null) return;

        var contactPoint = collision.GetContact(0).point;

        targetable.Hit(
            new HitInfoDto
            {
                Damage = 5,
                HitPosition = contactPoint,
                Origin = contactPoint - this.DirectionVector
            }
        );
    }

    public void Launch(Vector3 direction_vector, int damage)
    {
        this.RigidBody.velocity = direction_vector * this.Speed;
        this.Damage = damage;
    }
}
