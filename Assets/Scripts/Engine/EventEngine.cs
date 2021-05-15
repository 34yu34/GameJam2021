using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Engine.Events;
using UnityEngine;

public class EventEngine
{
    private readonly EventEngineConstructorFacade _constructorFacade;

    private List<IEvent> _event_dictionary = new List<IEvent>
    {
        // Minor events
        new SolarStormEvent
        {
            ProbabilityWeight = 1
        },
        new SolarStormEvent
        {
            ProbabilityWeight = 2
        },
        new SolarStormEvent
        {
            ProbabilityWeight = 3
        },
        new SolarStormEvent
        {
            ProbabilityWeight = 200
        },

        // Major events
        new LavaRisingEvent
        {
            ProbabilityWeight = 1
        },
        new LavaRisingEvent
        {
            ProbabilityWeight = 10
        }
    };

    private Timestamp _next_event_timestamp;

    private readonly int MIN_SECONDS_UNTIL_EVENT;
    private readonly int MAX_SECONDS_UNTIL_EVENT;

    private readonly int MAJOR_EVENT_MIN_INDEX;
    private readonly int MAJOR_EVENT_MAX_INDEX;

    private int _current_event_index = 0;

    public EventEngine(
        EventEngineSettingDto settings,
        EventEngineConstructorFacade constructorFacade)
    {
        _constructorFacade = constructorFacade;

        MIN_SECONDS_UNTIL_EVENT = settings.MinSecondsUntilEvent;
        MAX_SECONDS_UNTIL_EVENT = settings.MaxSecondsUntilEvent;

        MAJOR_EVENT_MIN_INDEX = settings.MajorEventMinIndex;
        MAJOR_EVENT_MAX_INDEX = settings.MajorEventMaxIndex;
    }

    public void TryDoNextEvent()
    {
        if (_next_event_timestamp == null)
        {
            SetNextEventTimestamp();

            return;
        }

        if (!_next_event_timestamp.HasPassed()) return;

        ++_current_event_index;

        var is_major_event = ShouldTriggerMajorEvent();

        var next_event = SelectNextEvent(is_major_event);

        next_event.DoEvent(_constructorFacade);

        SetNextEventTimestamp();
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

    private IEvent SelectNextEvent(bool is_major_event)
    {
        var should_play_major_event = is_major_event && _event_dictionary.Any(x => x.IsMajor && x.CanHappen());

        var availableEvents = _event_dictionary.Where(x => x.CanHappen() && x.IsMajor == should_play_major_event).ToList();

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

    private static EventRange CreateEventRangeFromEvent(IEvent @event, ref int current_min)
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

        public IEvent Event { get; set; }
    }
}
