using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventShower : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private string _event_name;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Timestamp _event_time;

    private void Start()
    {
        _event_time = Timestamp.Now();
    }

    public void SetNextEvent(Event next_event, float in_time)
    {
        _event_time = Timestamp.In(in_time);

        _event_name = next_event.Name;
    }

    public void Update()
    {
        if (!_event_time.HasPassed())
        {
            _text.text = $"INCOMING EVENT :\n{_event_name}\nIN\n{(_event_time.Value - Time.time).ToString("0.0")}";
            return;
        }

        _text.text = "";
    }

}
