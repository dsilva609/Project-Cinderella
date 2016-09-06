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
            var field = type.GetField(name);
            var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
            return attr?.Name ?? value.ToString();
        }
    }
}