using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ShotComponent : MonoBehaviour
{
    [SerializeField] 
    private float _range;

    [SerializeField] 
    private int _damage;

    [SerializeField]
    private ParticleSystem shotEffect;


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
        if (!Physics.Raycast(transform.position, transform.forward, out var hit, _range))
        {
            return;
        }

        var hitInfo = CreateHitInfo(hit);

        hit.rigidbody.GetComponent<Targetable>()?.Hit(hitInfo);
    }

    private HitInfo CreateHitInfo(RaycastHit hit)
    {
        return new HitInfo
        {
            Damage = _damage,
            Origin = transform.position,
            HitPosition = hit.point
        };
    }

    private void CreateShotEffect()
    {
        var obj = Instantiate(shotEffect);
        obj.transform.position = transform.position;
        obj.transform.LookAt(transform.position + transform.forward);
        obj.Play();
        Destroy(obj.gameObject, 0.2f);
    }
}
