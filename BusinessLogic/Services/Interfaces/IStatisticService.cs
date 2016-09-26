namespace BusinessLogic.Services.Interfaces
{
    public interface IStatisticService
    {
        int GetCollectionCount();

        int GetNumNew();

        int GetNumUsed();

        int GetNumPhysical();

        int GetNumDigital();

        int GetTimesCompleted();

        int GetNumInProgress();

        int GetNumNotStarted();

        int GetNumCheckedOut();
    }
}