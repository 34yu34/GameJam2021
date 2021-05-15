using UnityEngine;

public class ShotComponent : MonoBehaviour
{
    [SerializeField] 
    private float _range;

    [SerializeField] 
    private int _damage;

    [SerializeField]
    private ParticleSystem _shot_effect;

    [SerializeField]
    private Projectile _projectile;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        CreateShotEffect();

        var projectile = Instantiate(_projectile);
        projectile.transform.position = transform.position;
        projectile.transform.LookAt(transform.position + transform.forward);

        projectile.Launch(transform.forward, _damage);
        
    }

    private void CreateShotEffect()
    {
        var obj = Instantiate(_shot_effect);
        obj.transform.position = transform.position;
        obj.transform.LookAt(transform.position + transform.forward);
        obj.Play();
        Destroy(obj.gameObject, 0.2f);
    }
}
