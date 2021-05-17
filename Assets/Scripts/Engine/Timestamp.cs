using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Timestamp
{
    private float _timestamp;

    private Timestamp(float seconds = 0)
    {
        _timestamp = Time.time + seconds;
    }

    public static Timestamp Now()
    {
        return new Timestamp();
    }

    public static Timestamp In(float seconds)
    {
        return new Timestamp(seconds);
    }

    public static Timestamp Back(float seconds)
    {
        return new Timestamp(-seconds);
    }

    public bool HasPassed()
    {
        return _timestamp < Time.time;
    }

    public float Value => _timestamp;
}
