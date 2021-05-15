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

    private EventEngineConstructorFacade _constructorFacade;

    public void Start()
    {
        var player = FindObjectOfType<Player>();
        _constructorFacade = new EventEngineConstructorFacade(player);

        _event_engine = gameObject.GetComponent<EventEngine>();

        _event_engine.GenerateEvent(
                new EventEngineSettingDto
                {
                    MinSecondsUntilEvent = _minSecondsUntilEvent,
                    MaxSecondsUntilEvent = _maxSecondsUntilEvent,
                    MajorEventMinIndex = _majorEventMinIndex,
                    MajorEventMaxIndex = _majorEventMaxIndex
                },
                _constructorFacade
            );
    }

    public void Update()
    {
        var occuring_event_duration = _event_engine.TryDoNextEvent();

        if (occuring_event_duration == -1) return;

        Invoke(nameof(UndoCurrentEvent), occuring_event_duration);
    }

    private void UndoCurrentEvent()
    {
        _event_engine.UndoCurrentEvent(_constructorFacade);
    }
}
