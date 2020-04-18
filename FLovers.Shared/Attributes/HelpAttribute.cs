using System;

namespace FLovers.Shared.Attributes
{
    /// <summary>
    /// usage [Help("This is how we use this attribute on classes")]
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class HelpAttribute : Attribute
    {
        public readonly string Example;


        public HelpAttribute(string example)
        {
            Example = example;
        }

    }
}
