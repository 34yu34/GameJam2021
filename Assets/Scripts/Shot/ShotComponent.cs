using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(MunitionComponent))]
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

    private MunitionComponent _munitions;
    public MunitionComponent Munitions => _munitions ??= gameObject.GetComponent<MunitionComponent>();


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

        if (!Munitions.Shoot())
        {
            return;
        }

        CreateShotEffect();

        if (!Physics.Raycast(_aim_camera_object.position, _aim_camera_object.forward, out var hit, _range))
        {
            create_projectile(_aim_camera_object.position + _aim_camera_object.forward * _range);

            return;
        }
        
        create_projectile(hit.point);

        hit.rigidbody?.GetComponent<Targetable>()?.Hit(new HitInfoDto

        {
            Damage = _damage,
            HitPosition = hit.point,
            Origin = transform.position
        });

    }

    private void create_projectile(Vector3 target_pos)
    {
        var projectile = Instantiate(_projectile);

        projectile.transform.position = this.transform.position;

        projectile.transform.LookAt(transform.position + transform.forward);

        projectile.Launch(transform.forward, target_pos);
    }

    private void CreateShotEffect()
    {
        if(_shot_effect == null)
        {
            return;
        }
        var obj = Instantiate(_shot_effect);
        
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.position = transform.position;
        obj.transform.LookAt(transform.position + transform.forward);
        
        obj.Play();
        
        Destroy(obj.gameObject, 0.2f);
    }
}
