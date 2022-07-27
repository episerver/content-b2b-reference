namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Login Page",
    GUID = "41c4c93e-6369-4259-bc2e-9696c602a796",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Login Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class LoginPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Username", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string UsernameLabel { get; set; }

    [HiddenInput(DisplayValue = false)]
    public virtual string Username { get; set; }

    [CultureSpecific]
    [Display(Name = "Password", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string PasswordLabel { get; set; }

    [HiddenInput(DisplayValue = false)]
    public virtual string Password { get; set; }

    [CultureSpecific]
    [Display(Name = "Forget Password Text", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string ForgetPasswordText { get; set; }

    [Display(Name = "Forget Password Link", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual Url ForgetPasswordLink { get; set; }

    [CultureSpecific]
    [Display(Name = "RememberMe Text", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string RememberMeLabel { get; set; }

    [HiddenInput(DisplayValue = false)]
    public virtual bool RememberMe { get; set; }

    [CultureSpecific]
    [Display(Name = "SignIn Text", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string SignInText { get; set; }

    [CultureSpecific]
    [Display(Name = "Create Account Text", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string CreateAccountText { get; set; }

    [Display(Name = "Create Account Link", GroupName = SystemTabNames.Content, Order = 9)]
    public virtual Url CreateAccountLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Guest Login Title", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string GuestLoginTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Guest Login Description", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string GuestLoginDescription { get; set; }

    [CultureSpecific]
    [Display(Name = "Guest Login Button Text", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string GuestLoginButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Login Title", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string LoginTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "No Account Label", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string NoAccountLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Login";
        UsernameLabel = "Username";
        PasswordLabel = "Password";
        ForgetPasswordText = "Forgot Password?";
        RememberMeLabel = "Remember me";
        SignInText = "Sign In";
        CreateAccountText = "Create Account";
        GuestLoginTitle = "Guest & New Customers";
        GuestLoginDescription =
            "Continue to checkout without signing in,you will have the opportunity to register after checkout.";
        GuestLoginButtonText = "Continue as Guest";
        LoginTitle = "Registered Customers";
        NoAccountLabel = "Don’t have an account? ";
    }
}
