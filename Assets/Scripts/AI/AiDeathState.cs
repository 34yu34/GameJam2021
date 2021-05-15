using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class AiDeathState : AiState
{
    public override int StateId => 2;
    private Damageable _damageable_component;

    private Timestamp _timestamp;

    private void Start()
    {
    }

    public override AiState NextState()
    {
        return this;
    }

    public override void Act()
    {
        Debug.Log("Dead");

        if (_timestamp == null) _timestamp = Timestamp.In(5f);

        if (_timestamp.HasPassed())
        {
            Destroy(this.gameObject);
        }

    }

}
