using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseSoundbankManager : MonoBehaviour
{
    private void Awake()
    {
        int amount = 0;

        foreach (WwiseSoundbankManager wwiseController in FindObjectsOfType<WwiseSoundbankManager>())
            amount++;

        if (amount == 1)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        AkBankManager.LoadBank("Music", false, false);
        AkBankManager.LoadBank("SFX", false, false);
    }
}
