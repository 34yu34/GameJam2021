using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MunitionComponent : MonoBehaviour
{
    [SerializeField] 
    private int _max_ammo;
    public int MaxAmmo => _max_ammo;

    
    [SerializeField] 
    private int _magazine_size;
    public int MagazineSize => _magazine_size;


    private int _leftover_ammo;
    public int LeftOverAmmo
    {
        get => _leftover_ammo;

        set => _leftover_ammo = Mathf.Clamp(value, 0, MaxAmmo);
    }


    private int _current_ammo;
    public int CurrentAmmo
    {
        get => _current_ammo;
        set => _current_ammo = Mathf.Clamp(value, 0, _magazine_size);
    }


    private void Start()
    {
        CurrentAmmo = _magazine_size;
        LeftOverAmmo = _max_ammo;
    }

    public bool Shoot()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo -= 1;
            return true;
        }
        
        Reload();
        return false;
    }

    public void Reload()
    {
        var needed_ammo = MagazineSize - CurrentAmmo;

        var ammo_to_add = Mathf.Clamp(needed_ammo, 0 , _leftover_ammo);

        LeftOverAmmo -= ammo_to_add;

        CurrentAmmo = MagazineSize;

    }

    public void GiveAmmo(int ammout)
    {
        LeftOverAmmo += ammout;
    }
}
