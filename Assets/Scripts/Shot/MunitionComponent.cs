using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionComponent : MonoBehaviour
{
    [SerializeField] 
    private int _max_ammo;

    private int _current_ammo;

    public int CurrentAmmo
    {
        get => _current_ammo;
        set => _current_ammo = Mathf.Clamp(value, 0, _max_ammo);
    }

    private void Start()
    {
        _current_ammo = _max_ammo;
    }

    public bool Shoot()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo -= 1;
            return true;
        }

        return false;
    }

    public void GiveAmmo(int ammout)
    {
        CurrentAmmo += ammout;
    }
}
