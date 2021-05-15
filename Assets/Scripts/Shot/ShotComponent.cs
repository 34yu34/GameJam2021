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


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

 
    private void Shoot()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out var hit, _range))
        {
            return;
        }

        Debug.DrawLine(transform.position, hit.point, Color.blue);

        var damageable = hit.rigidbody.GetComponent<Targetable>()?.Damageable;

        if (damageable == null)
        {
            return;
        }

        damageable.TakeDamage(_damage);
    }
}
