namespace Sample.Models.Attributes;

public class LocalizedRequiredIfAttribute : LocalizedRequiredAttribute
{
    public string DependentProperty { get; set; }
    public object TargetValue { get; set; }

    public LocalizedRequiredIfAttribute(
        string translationPath,
        string dependentProperty,
        object targetValue
    ) : base(translationPath)
    {
        DependentProperty = dependentProperty;
        TargetValue = targetValue;
    }

    protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext
    )
    {
        var containerType = validationContext.ObjectInstance.GetType();
        var field = containerType.GetProperty(DependentProperty);
        if (field != null)
        {
            var dependentValue = field.GetValue(validationContext.ObjectInstance, null);

            if (
                (dependentValue == null && TargetValue == null)
                || (dependentValue != null && dependentValue.Equals(TargetValue))
            )
            {
                if (!IsValid(value))
                {
                    return new ValidationResult(
                        ErrorMessage,
                        new[] { validationContext.MemberName }
                    );
                }
            }
        }
        return ValidationResult.Success;
    }
}
