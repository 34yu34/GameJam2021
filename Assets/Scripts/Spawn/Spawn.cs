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
    private float _stamina_to_give;
    public float StaminaToGive => _stamina_to_give;

    [SerializeField] 
    private float _lifetime;
    public float Lifetime => _lifetime;

    [SerializeField]
    [NaughtyAttributes.MinMaxSlider(0, 10)]
    private int _weight = 3;
    public int Weight => _weight;

    [SerializeField]
    bool _is_eternal = false;

    private void  Start()
    {
        var collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        if (!_is_eternal)
        {
            Destroy(gameObject, Lifetime);
        }
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
        obj.Stamina.GiveStamina(StaminaToGive);

        Destroy(this.gameObject);
    }
    
}
