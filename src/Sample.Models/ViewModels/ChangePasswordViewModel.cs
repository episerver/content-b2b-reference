namespace Sample.Models.ViewModels;

public class ChangePasswordViewModel
{
    [LocalizedRequired("/ChangePassword/Form/Empty/CurrentPassword")]
    public string CurrentPassword { get; set; }

    [LocalizedRequired("/ChangePassword/Form/Empty/Password")]
    public string Password { get; set; }

    [LocalizedRequired("/ChangePassword/Form/Empty/ConfirmPassword")]
    [LocalizedCompare("Password", "/ChangePassword/Form/Error/InvalidConfirmPassword")]
    public string ConfirmPassword { get; set; }
}