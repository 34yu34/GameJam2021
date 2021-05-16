using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunitionInfo : MonoBehaviour
{
    [SerializeField]
    private Text _munition_text;

    private ShootInput _shoot_input;

    private ShootInput ShootInput => _shoot_input ??= GetComponentInParent<ShootInput>();

    private void Update()
    {
        _munition_text.text =
            $"{ShootInput.ShotComponent.Munitions.CurrentAmmo} / {ShootInput.ShotComponent.Munitions.LeftOverAmmo}";
    }
}
