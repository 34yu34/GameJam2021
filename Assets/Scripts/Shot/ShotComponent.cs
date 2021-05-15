using UnityEngine;
using NaughtyAttributes;

public class ShotComponent : MonoBehaviour
{
    [SerializeField] 
    private float _range;

    [SerializeField] 
    private int _damage;


    private bool _should_shoot;
    
    [SerializeField]
    private ParticleSystem _shot_effect;

    [SerializeField]
    private Projectile _projectile;

    [SerializeField]
    [Required]
    private Transform _aim_camera_object;

    public void SetShoot()
    {
        _should_shoot = true;
    }

    private void FixedUpdate()
    {
        if (_should_shoot)
        {
            shoot();
        }
    }

    private void shoot()
    {
        _should_shoot = false;

        CreateShotEffect();

        if (!Physics.Raycast(_aim_camera_object.position, _aim_camera_object.forward, out var hit, _range))
        {
            return;
        }
        
        create_projectile(hit);

        hit.rigidbody?.GetComponent<Targetable>()?.Hit(new HitInfoDto

        {
            Damage = _damage,
            HitPosition = hit.point,
            Origin = transform.position
        });

    }

    private void create_projectile(RaycastHit hit)
    {
        var projectile = Instantiate(_projectile);

        projectile.transform.position = this.transform.position;

        projectile.transform.LookAt(transform.position + transform.forward);

        projectile.Launch(transform.forward, hit.point);
    }

    private void CreateShotEffect()
    {
        var obj = Instantiate(_shot_effect);
        
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.position = transform.position;
        obj.transform.LookAt(transform.position + transform.forward);
        
        obj.Play();
        
        Destroy(obj.gameObject, 0.2f);
    }
}
