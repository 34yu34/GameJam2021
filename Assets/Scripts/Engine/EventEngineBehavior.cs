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

    public void Awake()
    {
        _event_engine =
            new EventEngine(
                new EventEngineSettingDto
                {
                    MinSecondsUntilEvent = _minSecondsUntilEvent,
                    MaxSecondsUntilEvent = _maxSecondsUntilEvent,
                    MajorEventMinIndex = _majorEventMinIndex,
                    MajorEventMaxIndex = _majorEventMaxIndex
                },
                new EventEngineConstructorFacade
                {

                }
            );
    }

    public void Update()
    {
        _event_engine.TryDoNextEvent();
    }
}
