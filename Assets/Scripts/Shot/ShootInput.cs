using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ShootInput : MonoBehaviour
{
    private ShotComponent shotComponent;

    private void Start()
    {
        shotComponent = GetComponentInChildren<ShotComponent>();

        Debug.Assert(shotComponent != null, "Object must have a gun");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shotComponent.SetShoot();
        }
    }

}
