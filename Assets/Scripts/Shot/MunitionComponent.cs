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

    [SerializeField]
    private bool _has_infinite_ammo;

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

    public bool TryShoot()
    {
        if (_has_infinite_ammo)
        {
            return true;
        }

        if (CurrentAmmo > 0)
        {
            CurrentAmmo -= 1;
            return true;
        }
        

        return false;
    }

    public void Reload()
    {
        var needed_ammo = (MagazineSize - CurrentAmmo);

        var ammo_to_add = Mathf.Clamp(needed_ammo, 0 , LeftOverAmmo);

        LeftOverAmmo -= ammo_to_add;

        CurrentAmmo = CurrentAmmo + ammo_to_add;
    }

    public void GiveAmmo(int ammout)
    {
        LeftOverAmmo += ammout;

        AkSoundEngine.PostEvent("Pick_Ammo", gameObject);
    }

    public bool IsFull()
    {
        return CurrentAmmo == MagazineSize;
    }
}
