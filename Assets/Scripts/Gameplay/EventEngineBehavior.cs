using UnityEngine;

public class EventEngineBehavior : MonoBehaviour
{
    private EventEngine _event_engine;

    private Event _event;

    [SerializeField]
    private int _minSecondsUntilEvent = 5;

    [SerializeField]
    private int _maxSecondsUntilEvent = 10;

    [SerializeField]
    private int _majorEventMinIndex = 3;

    [SerializeField]
    private int _majorEventMaxIndex = 5;

    public void Start()
    {
        _event_engine = gameObject.GetComponent<EventEngine>();

        _event_engine.SetEventEngineSettings(
                new EventEngineSettingDto
                {
                    MinSecondsUntilEvent = _minSecondsUntilEvent,
                    MaxSecondsUntilEvent = _maxSecondsUntilEvent,
                    MajorEventMinIndex = _majorEventMinIndex,
                    MajorEventMaxIndex = _majorEventMaxIndex
                }
            );
    }

    public void Update()
    {
        var response = _event_engine.TryGetNextEvent();

        if (!response.EventIsReady) return;

        _event = response.Event;

        AkSoundEngine.SetSwitch("Event", _event.SoundName, gameObject);

        AkSoundEngine.PostEvent(_event.IsMajor ? "Event_Alert_Major" : "Event_Alert_Minor", gameObject);

        Invoke(nameof(DoCurrentEvent), 25);

        Invoke(nameof(UndoCurrentEvent), _event.DurationInSeconds);
    }

    private void DoCurrentEvent()
    {
        AkSoundEngine.PostEvent("Environment_Event", gameObject);

        _event.DoEvent();
    }

    private void UndoCurrentEvent()
    {
        _event_engine.UndoCurrentEvent();
    }
}
