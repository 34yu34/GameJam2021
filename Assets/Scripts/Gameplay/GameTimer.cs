using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float _timestamp_begin;
    public float TimestampBegin => _timestamp_begin;

    private float _timestamp_end;
    public float TimestampEnd => _timestamp_end;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartTimer();
    }

    public void StartTimer()
    {
        _timestamp_begin = Time.time;
    }

    public void StopTimer()
    {
        _timestamp_end = Time.time;
    }
}
