using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Spawn : MonoBehaviour
{
    [SerializeField] 
    private int _munition_to_give;
    public int MunitionToGive => _munition_to_give;

    [SerializeField] 
    private int _health_to_give;
    public int HealthToGive => _health_to_give;

    [SerializeField] 
    private float _lifetime;
    public float Lifetime => _lifetime;


    private void  Start()
    {
        var collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        Destroy(gameObject, Lifetime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var obj = collider.GetComponent<Player>();

        if (obj == null)
        {
            return;
        }

        obj.Damageable.Heal(HealthToGive);
        obj.ShootInput.ShotComponent.Munitions.GiveAmmo(MunitionToGive);

        Destroy(this.gameObject);
    }
    
}
