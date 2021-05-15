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

        var hitInfo = new HitInfo();
        hitInfo.Damage = _damage;
        hitInfo.Origin = transform.position;
        hitInfo.HitPosition = hit.point;

        hit.rigidbody.GetComponent<Targetable>()?.Hit(hit, _damage);
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
