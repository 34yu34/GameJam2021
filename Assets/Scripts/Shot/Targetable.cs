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

    public void Hit(HitInfoDto hitInfoDto)
    {
        CreateHitEffect(hitInfoDto, hitEffect);

        Damageable.TakeDamage(hitInfoDto.Damage);
    }
    public static void CreateHitEffect(HitInfoDto hitInfoDto, ParticleSystem hitEffect = null)
    {
        if (hitEffect == null)
        {
            hitEffect = ShotManager.Instance.BasicEffect;
        }

        var obj = Instantiate(hitEffect);
        obj.transform.position = hitInfoDto.HitPosition;
        obj.transform.LookAt(hitInfoDto.Origin);
        obj.Play();
        Destroy(obj.gameObject, 0.2f);
    }
}
