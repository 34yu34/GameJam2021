using UnityEngine;

public class EventEngineBehavior : MonoBehaviour
{
    private EventEngine _event_engine;

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
        var response = _event_engine.TryDoNextEvent();

        if (!response.EventWasTriggered) return;

        Invoke(nameof(UndoCurrentEvent), response.EventDurationInSeconds);
    }

    private void UndoCurrentEvent()
    {
        _event_engine.UndoCurrentEvent();
    }
}
