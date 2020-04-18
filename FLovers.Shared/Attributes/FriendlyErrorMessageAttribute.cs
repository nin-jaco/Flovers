using System;

namespace FLovers.Shared.Attributes
{
    /// <summary>
    /// We don't want to display a yellow screen of death or exception to the user. 
    /// </summary>
    public class FriendlyErrorMessageAttribute : Attribute
    {
        public string FriendlyErrorMessage;

        [Help(@"For use in the Error properties for Response types.  This is the error message to be displayed to the end user.")]
        public FriendlyErrorMessageAttribute(string friendlyErrorMessage)
        {
            FriendlyErrorMessage = friendlyErrorMessage;
        }
    }
}
