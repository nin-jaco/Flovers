using System.ComponentModel;
using System.Runtime.Serialization;
using FLovers.Shared.Attributes;

namespace FLovers.Shared.Enums
{
    [Help(@"string enumDescription = ErrorsEnum.Description();"), DataContract(Namespace = "FLovers.Shared.Enums", Name = "ErrorsEnum")]
    public enum ErrorsEnum
    {
        [Description("Exception Thrown."), FriendlyErrorMessage("An exception was encountered during this request. The Error has been logged and forwarded to the developers for attention."), EnumMember(Value = "ExceptionEncountered")]
        ExceptionEncountered = 0,
    }
}
