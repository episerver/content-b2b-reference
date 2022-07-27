namespace Sample.Models.ViewModels;

public class LoginViewModel
{
    [LocalizedRequired("/Login/Form/Empty/Username")]
    public string Username { get; set; }

    [LocalizedRequired("/Login/Form/Empty/Password")]
    public string Password { get; set; }

    public string CreateAccountLink { get; set; }
    public string ForgetPasswordLink { get; set; }
    public string ReturnUrl { get; set; }
    public bool IsGuestUser { get; set; }
    public bool ShouldShowGuestUserButton { get; set; }
    public string RememberMe  { get; set; }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}