public interface IEvent
{
    bool IsMajor { get; }

    int ProbabilityWeight { get; set; }

    void DoEvent();
 
    bool CanHappen();
}
