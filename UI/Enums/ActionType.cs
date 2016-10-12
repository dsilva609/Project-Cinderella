using System.Collections.Generic;

namespace UI.Enums
{
    public class ActionType
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static ActionType CreateNew = new ActionType { Name = "Create", Value = "Create" };
        public static ActionType EditExisting = new ActionType { Name = "Edit Existing", Value = "Edit" };
        public static ActionType ViewCollection = new ActionType { Name = "View Collection", Value = "Index" };
        public static ActionType SearchOnline = new ActionType { Name = "Search Online", Value = "Search" };

        public IEnumerable<ActionType> GetTypes()
        {
            yield return CreateNew;
            yield return EditExisting;
            yield return ViewCollection;
            yield return SearchOnline;
        }
    }
}