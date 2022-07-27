namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Create Account Page",
    GUID = "81d5be11-5a91-42d4-8b01-d070468af9f1",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Create a New Account"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class CreateAccountPage : BasePage
{
    [CultureSpecific]
    [Display(
        Name = "Required Message",
        Description = "Required Message",
        GroupName = Global.GroupNames.Labels,
        Order = 2
    )]
    public virtual string RequiredMessage { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Instruction",
        Description = "Instruction",
        GroupName = Global.GroupNames.Labels,
        Order = 3
    )]
    public virtual XhtmlString Instruction { get; set; }

    [CultureSpecific]
    [Display(
        Name = "SubscriptionMessage",
        Description = "SubscriptionMessage",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string SignMeUp { get; set; }

    [CultureSpecific]
    [Display(
        Name = "ButtonText",
        Description = "Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 5
    )]
    public virtual string ButtonText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Email Address Label",
        Description = "Email Address Label",
        GroupName = Global.GroupNames.Labels,
        Order = 6
    )]
    public virtual string EmailAddressLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Username Label",
        Description = "Username Label",
        GroupName = Global.GroupNames.Labels,
        Order = 7
    )]
    public virtual string UsernameLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Password Label",
        Description = "Password Label",
        GroupName = Global.GroupNames.Labels,
        Order = 8
    )]
    public virtual string PasswordLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Confirm Password Label",
        Description = "Confirm Password Label",
        GroupName = Global.GroupNames.Labels,
        Order = 9
    )]
    public virtual string ConfirmPasswordLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Sign Me Up Text",
        Description = "Sign Me Up Text",
        GroupName = Global.GroupNames.Labels,
        Order = 10
    )]
    public virtual string SignMeUpText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Have Account Text",
        Description = "have account Text",
        GroupName = Global.GroupNames.Labels,
        Order = 10
    )]
    public virtual string HaveAccountText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Sign in Text",
        Description = "Sign in Text",
        GroupName = Global.GroupNames.Labels,
        Order = 10
    )]
    public virtual string SigninText { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Create Account";
        RequiredMessage = "Required";
        SignMeUp = "Sign me up for newsletters and product updates.";
        ButtonText = "Create Account";
        EmailAddressLabel = "Email Address";
        UsernameLabel = "Username";
        PasswordLabel = "Password";
        ConfirmPasswordLabel = "Confirm Password";
        SignMeUpText = "Sign me up for newsletters and product updates.";
        RequiredMessage = "Required*";
        Instruction = new XhtmlString(
            $"<p><strong>Password Requirements:</strong></p>{Environment.NewLine}<p>Password must be at least 7 characters long.<br />"
                + "Password must include at least one number.</p>"
        );
        SigninText = "Sign in";
        HaveAccountText = "Already have an account?";
    }
}
