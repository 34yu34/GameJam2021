using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    [SerializeField]
    private float _max_stamina;
    public float MaxStamina => _max_stamina;

    [SerializeField] 
    private float _stamina_usage_rate;

    [SerializeField]
    private float _stamina_regen_rate;

    private bool is_regenarating;

    private float _current_stamina;

    public float CurrentStamina
    {
        get => _current_stamina;
        private set => _current_stamina = Mathf.Clamp(value, 0f, _max_stamina);
    }

    private void Start()
    {
        CurrentStamina = _max_stamina;
    }

    private void FixedUpdate()
    {
        CurrentStamina += (is_regenarating ? _stamina_regen_rate : - _stamina_usage_rate) * Time.fixedDeltaTime;
        is_regenarating = true;
    }

    public bool TrySprint()
    {
        is_regenarating = false;
        return CurrentStamina > 0f;
    }


}
