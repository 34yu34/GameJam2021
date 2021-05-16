using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventEngine : MonoBehaviour
{
    [SerializeField]
    private List<Event> _event_dictionary;
 
    private Timestamp _next_event_timestamp;

    private int MIN_SECONDS_UNTIL_EVENT;
    private int MAX_SECONDS_UNTIL_EVENT;

    private int MAJOR_EVENT_MIN_INDEX;
    private int MAJOR_EVENT_MAX_INDEX;

    private int _current_event_index = 0;

    private Event _current_event;

    private void Start()
    {
        foreach (var @event in _event_dictionary)
        {
            @event.ResetEvent();
        }
    }

    public void SetEventEngineSettings(EventEngineSettingDto settings)
    {
        MIN_SECONDS_UNTIL_EVENT = settings.MinSecondsUntilEvent;
        MAX_SECONDS_UNTIL_EVENT = settings.MaxSecondsUntilEvent;

        MAJOR_EVENT_MIN_INDEX = settings.MajorEventMinIndex;
        MAJOR_EVENT_MAX_INDEX = settings.MajorEventMaxIndex;
    }

    public EventResponse TryDoNextEvent()
    {
        if (_next_event_timestamp == null)
        {
            SetNextEventTimestamp();

            return new EventResponse
            {
                EventWasTriggered = false
            };
        }

        if (!_next_event_timestamp.HasPassed())
        {
            return new EventResponse
            {
                EventWasTriggered = false
            };
        }

        ++_current_event_index;

        var is_major_event = ShouldTriggerMajorEvent();

        _current_event = SelectNextEvent(is_major_event);

        if (_current_event == null)
        {
            return new EventResponse
            {
                EventWasTriggered = false
            };
        }

        _current_event.DoEvent();

        SetNextEventTimestamp();

        return new EventResponse
        {
            EventDurationInSeconds = _current_event.DurationInSeconds,
            EventWasTriggered = true
        };
    }

    public void UndoCurrentEvent()
    {
        _current_event.UndoEvent();
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

        var event_ranges =
            availableEvents
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

public class EventEngineSettingDto
{
    public int MinSecondsUntilEvent { get; set; }
    public int MaxSecondsUntilEvent { get; set; }
    public int MajorEventMinIndex { get; set; }
    public int MajorEventMaxIndex { get; set; }
}

public class EventResponse
{
    public bool EventWasTriggered { get; set; }

    public int EventDurationInSeconds { get; set; }
}
