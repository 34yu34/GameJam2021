using TMPro;
using UnityEngine;

public abstract class Event : MonoBehaviour
{
    public bool IsMajor { get; }

    [SerializeField]
    private int _probability_weight;
    public int ProbabilityWeight => _probability_weight;

    [SerializeField] 
    private int _duration_in_seconds;
    public int DurationInSeconds => _duration_in_seconds;

    public abstract void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade);

    public abstract void UndoEvent(EventEngineConstructorFacade engineConstructorFacade);

    public abstract bool CanHappen();
}
