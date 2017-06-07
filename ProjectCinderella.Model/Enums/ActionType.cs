using System.Collections.Generic;
using System.Linq;

namespace ProjectCinderella.Model.Enums
{
	public class ActionType
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public static ActionType CreateNew = new ActionType { Name = "Create", Value = "Create" };
		public static ActionType ViewCollection = new ActionType { Name = "View Collection", Value = "Index" };
		public static ActionType SearchOnline = new ActionType { Name = "Search Online", Value = "Search" };

		public static IEnumerable<ActionType> GetTypes(bool authenticated)
		{
			if (authenticated)
			{
				yield return CreateNew;
				yield return ViewCollection;
				yield return SearchOnline;
			}
			else yield return ViewCollection;
		}

		public static ActionType GetByValue(string value)
		{
			return string.IsNullOrWhiteSpace(value) ? ViewCollection : GetTypes(true).SingleOrDefault(x => x.Value == value);
		}
	}
}