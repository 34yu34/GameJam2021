public interface IEvent
{
    bool IsMajor { get; }

    int ProbabilityWeight { get; set; }

    int? DurationInSeconds { get; }

    void DoEvent(EventEngineConstructorFacade eventEngineConstructorFacade);

    void UndoEvent(EventEngineConstructorFacade engineConstructorFacade);
 
    bool CanHappen();
}
