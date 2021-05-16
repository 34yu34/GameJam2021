
using UnityEngine;
using System;

public class GameTimer : MonoBehaviour
{
    private float _timestamp_begin;
    public float TimestampBegin => _timestamp_begin;

    private float _timestamp_end;
    public float TimestampEnd => _timestamp_end;

    public string DisplayCurrent
    {
        get
        {
            var time = (Time.time - TimestampBegin);
            return TimeSpan.FromSeconds(time).ToString("mm\\:ss");
        }
    }

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
