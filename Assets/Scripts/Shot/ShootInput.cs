using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ShootInput : MonoBehaviour
{
    private ShotComponent _shotComponent;
    public ShotComponent ShotComponent => _shotComponent ??= GetComponentInChildren<ShotComponent>();

    private void Start()
    {
        _shotComponent = GetComponentInChildren<ShotComponent>();

        Debug.Assert(_shotComponent != null, "Object must have a gun");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShotComponent.SetShoot();
        }
    }

}
