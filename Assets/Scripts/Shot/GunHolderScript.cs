using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GunHolderScript : MonoBehaviour
{
    private Animator _anim;
    private Animator Anim => _anim ??= gameObject.GetComponent<Animator>();

    public void Reload(float? speed = null)
    {
        if (speed.HasValue)
        {
            Anim.SetFloat("ReloadTime", speed.Value);
        }

        Anim.ResetTrigger("Reload");
        Anim.SetTrigger("Reload");

        AkSoundEngine.PostEvent("Player_Reload", gameObject);
    }
}
