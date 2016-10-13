namespace BusinessLogic.Services.Interfaces
{
    public interface IStatisticService
    {
        int GetCollectionCount(string userID = "");

        int GetNumNew(string userID = "");

        int GetNumUsed(string userID = "");

        int GetNumPhysical(string userID = "");

        int GetNumDigital(string userID = "");

        int GetTimesCompleted(string userID = "");

        int GetNumInProgress(string userID = "");

        int GetNumNotStarted(string userID = "");

        int GetNumCompleted(string userID = "");

        int GetNumCheckedOut(string userID = "");

        int GetNumAlbums(string userID = "");

        int GetNumBooks(string userID = "");

        int GetNumMoviesShows(string userID = "");

        int GetNumGames(string userID = "");
    }
}