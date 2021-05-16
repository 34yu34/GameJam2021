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
    private float _reload_time;

    private Timestamp _reload_timestamp;

    private GunHolderScript _gun_holder;

    [SerializeField]
    [Required]
    private Transform _aim_camera_object;

    private MunitionComponent _munitions;
    public MunitionComponent Munitions => _munitions ??= gameObject.GetComponent<MunitionComponent>();

    private void Start()
    {
        _gun_holder = GetComponentInParent<GunHolderScript>();
        _reload_timestamp = Timestamp.Now();
    }

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

        if (!_reload_timestamp.HasPassed())
        {
            return;
        }

        if (!Munitions.TryShoot())
        {
            Reload();
            return;
        }

        CreateShotEffect();

        if (!Physics.Raycast(_aim_camera_object.position, _aim_camera_object.forward, out var hit, _range))
        {
            create_projectile(_aim_camera_object.position + _aim_camera_object.forward * _range, _aim_camera_object.forward);

            return;
        }
        
        create_projectile(hit.point, (hit.point - _aim_camera_object.position).normalized);

        var hit_obj = hit.rigidbody?.GetComponent<Targetable>();

        var hit_dto = new HitInfoDto
        {
            Damage = _damage,
            HitPosition = hit.point,
            Origin = transform.position
        };

        hit_obj?.Hit(hit_dto);

        if (hit_obj == null)
        {
            Targetable.CreateHitEffect(hit_dto);
        }

    }

    public void Reload()
    {
        if (Munitions.IsFull())
        {
            return;
        }

        _reload_timestamp = Timestamp.In(_reload_time);

        Munitions.Reload();
        _gun_holder?.Reload();
    }
    
    private void create_projectile(Vector3 target_pos, Vector3 direction)
    {
        var projectile = Instantiate(_projectile);

        projectile.transform.position = this.transform.position;

        projectile.transform.LookAt(transform.position + direction);

        projectile.Launch(direction, target_pos);
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
