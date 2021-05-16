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
            AkSoundEngine.PostEvent("Bullet_Impact_Mud", FindObjectOfType<Player>().gameObject);
        }
        else
        {
            AkSoundEngine.PostEvent("Bullet_Impact_Metal", FindObjectOfType<Player>().gameObject);
        }

        var obj = Instantiate(hitEffect);
        obj.transform.position = hitInfoDto.HitPosition;
        obj.transform.LookAt(hitInfoDto.Origin);
        obj.Play();
        Destroy(obj.gameObject, 0.2f);
    }
}
