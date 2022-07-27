namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Forgot Password Page",
    GUID = "4a450d76-9ebb-4bc5-835c-790bff80d7c2",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create Forgot Password Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ForgotPasswordPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Pre Message", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string PreMessage { get; set; }

    [CultureSpecific]
    [Display(Name = "Post Message", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string PostMessage { get; set; }

    [HiddenInput(DisplayValue = false)]
    public virtual string Username { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Return to SignIn Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string ReturnToSignInButtonText { get; set; }

    [Display(
        Name = "Return to SignIn Button Link",
        GroupName = Global.GroupNames.Labels,
        Order = 5
    )]
    public virtual Url ReturnToSignInButtonLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Send Button Text", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string SendButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Close Button Text", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string CloseButtonText { get; set; }

    [Display(Name = "Close Button Link", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual Url CloseInButtonLink { get; set; }

    [CultureSpecific]
    [Display(Name = "User Name", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string UserNameLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Forgot Password";
        PreMessage =
            "Enter your username and we'll send you an email that will allow you to reset your password.";
        PostMessage =
            "If an account matches the username entered, an email will be sent to the associated email address with instructions on how to reset your password shortly. If you do not receive an email, please contact customer service.";
        UserNameLabel = "Username";
        ReturnToSignInButtonText = "Return to Sign In";
        SendButtonText = "Send Email";
        CloseButtonText = "Return to Home Page";
    }
}
