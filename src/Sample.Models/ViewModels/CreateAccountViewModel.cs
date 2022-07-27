namespace Sample.Models.ViewModels;

public class CreateAccountViewModel
{
    [LocalizedRequired("/CreateAccount/Form/Empty/Email")]
    [LocalizedEmail("/CreateAccount/Form/Error/InvalidEmail")]
    public string Email { get; set; }

    [LocalizedRequired("/CreateAccount/Form/Empty/Username")]
    public string Username { get; set; }

    [LocalizedRequired("/CreateAccount/Form/Empty/Password")]
    public string Password { get; set; }

    [LocalizedRequired("/CreateAccount/Form/Empty/ConfirmPassword")]
    [LocalizedCompare("Password", "/CreateAccount/Form/Error/InvalidConfirmPassword")]
    public string ConfirmPassword { get; set; }
    public string IsSubscribed { get; set; }
}