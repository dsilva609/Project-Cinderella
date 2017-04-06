using BusinessLogic.Enums;

namespace BusinessLogic.Models.Interfaces
{
    public interface IUserContext
    {
        bool IsAuthenticated();

        bool IsInRole(string role);

        string GetUserID();

        int GetUserNum();

        ItemType GetDefaultType();

        //TODO: move enum to business logic
        //ActionType GetDefaultAction();
    }
}