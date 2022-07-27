namespace Sample.Models.ViewModels;

public class ForgotPasswordViewModel
{
    [LocalizedRequired("/ForgotPassword/Form/Empty/Username")]
    public string Username { get; set; }
}