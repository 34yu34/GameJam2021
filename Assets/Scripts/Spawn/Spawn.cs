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


    private void  Start()
    {
        var collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        var obj = collider.GetComponent<Player>();

        if (obj == null)
        {
            return;
        }

        obj.GetComponent<Damageable>().Heal(_health_to_give);
    }
    
}
