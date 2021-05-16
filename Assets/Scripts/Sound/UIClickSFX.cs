using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSFX : MonoBehaviour
{
    public void PlayUIClickSFX()
    {
        AkSoundEngine.PostEvent("SFX_UI_Click", gameObject);
    }
}
