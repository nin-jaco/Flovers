using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLovers.Shared.Attributes;

namespace FLovers.Shared.Extensions
{
    /// <summary>
    /// Enum attributes and helper methods
    /// </summary>
    public static class EnumExtensions
    {
        [Help(@"string description = someColor.Description();")]
        public static string Description(this Enum someEnum)
        {
            var memInfo = someEnum.GetType().GetMember(someEnum.ToString());

            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return someEnum.ToString();
        }

        [Help(@"if (someColor.HasDescription())")]
        public static bool HasDescription(this Enum someEnum)
        {
            return !string.IsNullOrWhiteSpace(someEnum.Description());
        }
        public static bool HasDescription(this Enum someEnum, string expectedDescription)
        {
            return someEnum.Description().Equals(expectedDescription);
        }

        [Help(@"if (someColor.HasDescription(""indicates stop"", StringComparison.OrdinalIgnoreCase))")]
        public static bool HasDescription(this Enum someEnum, string expectedDescription, StringComparison comparisionType)
        {
            return someEnum.Description().Equals(expectedDescription, comparisionType);
        }

        [Help(@"var panda = EnumExtensions.GetValueFromDescription<Animal>(""Giant Panda"");")]
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "Description");
            // or return default(T);
        }


        

        [Help(@"string FriendlyErrorMessage = someColor.FriendlyErrorMessage();")]
        public static string FriendlyErrorMessage(this Enum someEnum)
        {
            var memInfo = someEnum.GetType().GetMember(someEnum.ToString());

            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(FriendlyErrorMessageAttribute), false);

                if (attrs.Length > 0)
                    return ((FriendlyErrorMessageAttribute)attrs[0]).FriendlyErrorMessage;
            }
            return someEnum.ToString();
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }


        public static List<string> GetDescriptionValuesOf<TEnum>()
            where TEnum : struct // can't constrain to enums so closest thing
        {
            return Enum.GetValues(typeof(TEnum)).Cast<Enum>()
                .Select(val => val.GetAttribute<DescriptionAttribute>().Description)
                .ToList();
        }


    }
}
