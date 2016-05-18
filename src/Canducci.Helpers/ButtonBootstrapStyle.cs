using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Canducci.Helpers
{
    public enum ButtonBootstrapStyle
    {
        [EnumDescription("")]
        None,
        [EnumDescription("btn btn-default")]
        Default,
        [EnumDescription("btn btn-primary")]
        Primary,
        [EnumDescription("btn btn-success")]
        Success,
        [EnumDescription("btn btn-info")]
        Info,
        [EnumDescription("btn btn-warning")]
        Warning,
        [EnumDescription("btn btn-danger")]
        Danger,
        [EnumDescription("btn btn-link")]
        Link
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumDescription : Attribute
    {
        public string Value { get; set; }
        public EnumDescription(string value = "")
        {
            Value = value;
        }
    }

    internal static class EnumDescriptionItem
    {
        public static string GetValue(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                IEnumerable<Attribute> attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs != null)
                {
                    IEnumerator<Attribute> p = attrs.GetEnumerator();                    
                    if (p.MoveNext())
                    {
                        return ((EnumDescription)p.Current).Value;
                    }
                }
            }
            return en.ToString();
        }
    }
    
}
