using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Damageable))]
public class Targetable : MonoBehaviour
{
    private Damageable _damageable;
    public Damageable Damageable => _damageable ??= GetComponent<Damageable>();

    [SerializeField]
    private ParticleSystem hitEffect;

    public void Hit(HitInfo hitInfo)
    {
        CreateHitEffect(hitInfo);

        Damageable.TakeDamage(hitInfo.Damage);
    }
    private void CreateHitEffect(HitInfo hitInfo)
    {
        var obj = Instantiate(hitEffect);
        obj.transform.position = hitInfo.HitPosition;
        obj.transform.LookAt(hitInfo.Origin);
        obj.Play();
        Destroy(obj.gameObject, 0.2f);
    }
}
