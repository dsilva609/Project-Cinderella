using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Enums
{
    public static class EnumHelpers
    {
        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return null;
            var field = type.GetField(name);
            if (field == null) return null;
            var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
            return attr?.Name;
        }
    }
}