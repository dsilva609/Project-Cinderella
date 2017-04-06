using BusinessLogic.Enums;
using UI.Enums;

namespace UI.Models.Interfaces
{
    public interface IUserContext
    {
        bool IsAuthenticated();

        bool IsInRole(string role);

        string GetUserID();

        int GetUserNum();

        ItemType GetDefaultType();

        ActionType GetDefaultAction();
    }
}