namespace Sample.Models.Attributes;

public class LocalizedPhoneNumberFormatAttribute : LocalizedRegularExpressionAttribute
{
    public LocalizedPhoneNumberFormatAttribute(string name)
        : base(@"^([\(\)/\-\.\+\s]*\d\s?(ext)?[\(\)/\-\.\+\s]*){10,}$", name) { }
}
