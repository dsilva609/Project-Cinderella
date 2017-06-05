using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.Model.Interfaces
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