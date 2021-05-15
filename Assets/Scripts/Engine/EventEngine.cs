using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Engine.Events;
using UnityEngine;

public class EventEngine : MonoBehaviour
{
    private EventEngineConstructorFacade _constructorFacade;

    [SerializeField]
    private List<Event> _event_dictionary;
 
    private Timestamp _next_event_timestamp;

    private int MIN_SECONDS_UNTIL_EVENT;
    private int MAX_SECONDS_UNTIL_EVENT;

    private int MAJOR_EVENT_MIN_INDEX;
    private int MAJOR_EVENT_MAX_INDEX;

    private int _current_event_index = 0;

    private Event _current_event;

    public void GenerateEvent(EventEngineSettingDto settings, EventEngineConstructorFacade constructorFacade)
    {
        _constructorFacade = constructorFacade;

        MIN_SECONDS_UNTIL_EVENT = settings.MinSecondsUntilEvent;
        MAX_SECONDS_UNTIL_EVENT = settings.MaxSecondsUntilEvent;

        MAJOR_EVENT_MIN_INDEX = settings.MajorEventMinIndex;
        MAJOR_EVENT_MAX_INDEX = settings.MajorEventMaxIndex;
    }

    public int TryDoNextEvent()
    {
        if (_next_event_timestamp == null)
        {
            SetNextEventTimestamp();

            return -1;
        }

        if (!_next_event_timestamp.HasPassed()) return -1;

        ++_current_event_index;

        var is_major_event = ShouldTriggerMajorEvent();

        _current_event = SelectNextEvent(is_major_event);

        if (_current_event == null) return -1;

        _current_event.DoEvent(_constructorFacade);

        SetNextEventTimestamp();

        return _current_event.DurationInSeconds;
    }

    public void UndoCurrentEvent(EventEngineConstructorFacade construsctor_facade)
    {
        _current_event.UndoEvent(construsctor_facade);
    }

    private bool ShouldTriggerMajorEvent()
    {
        if (_current_event_index < MAJOR_EVENT_MIN_INDEX) return false;

        var major_event_index = Random.Range(MAJOR_EVENT_MIN_INDEX, MAJOR_EVENT_MAX_INDEX + 1);

        if (_current_event_index < major_event_index) return false;

        // Reset event index for next major event
        _current_event_index = 0;

        return true;
    }

    private void SetNextEventTimestamp()
    {
        var next_event_time = Random.Range(MIN_SECONDS_UNTIL_EVENT, MAX_SECONDS_UNTIL_EVENT + 1);

        _next_event_timestamp = Timestamp.In(next_event_time);
    }

    private Event SelectNextEvent(bool is_major_event)
    {
        var should_play_major_event = is_major_event && _event_dictionary.Any(x => x.IsMajor && x.CanHappen());

        var availableEvents = _event_dictionary.Where(x => x.IsMajor == should_play_major_event && x.CanHappen()).ToList();

        if (!availableEvents.Any()) return null;

        var current_index = 0;

        var event_ranges = availableEvents
                                            .Select(@event => CreateEventRangeFromEvent(@event, ref current_index))
                                            .ToList();

        // current index is now equal to max + 1
        // Random.Range is (Inclusive, Exclusive)
        var event_index = Random.Range(0, current_index);

        return
            event_ranges
                .First(x => event_index >= x.Min && event_index <= x.Max)
                .Event;
    }

    private static EventRange CreateEventRangeFromEvent(Event @event, ref int current_min)
    {
        var current_max = current_min + @event.ProbabilityWeight;

        var eventRange = new EventRange
        {
            Min = current_min,
            Max = current_max,
            Event = @event
        };

        current_min = current_max + 1;

        return eventRange;
    }

    private class EventRange
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public Event Event { get; set; }
    }
}
