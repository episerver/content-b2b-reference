namespace Sample.Models.Pages;

[ContentType(
    DisplayName = "Reset Password Page",
    GUID = "57271de0-59ef-45e9-941f-a18d906450d3",
    Description = "To Reset New Password",
    GroupName = Global.GroupNames.CommercePages
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ResetPasswordPage : BasePage
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
        Name = "ButtonText",
        Description = "Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string ButtonText { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Sub Title",
        Description = "Title",
        GroupName = Global.GroupNames.Labels,
        Order = 5
    )]
    public virtual string SubTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "New Password",
        Description = "New Password",
        GroupName = Global.GroupNames.Labels,
        Order = 6
    )]
    public virtual string NewPasswordLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Confirm Password", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string ConfirmPasswordLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Reset Password";
        ButtonText = "Reset Password";
        SubTitle = "Enter your new password";
        NewPasswordLabel = "New Password:";
        ConfirmPasswordLabel = "Confirm Password:";
        RequiredMessage = "Required*";
        Instruction = new XhtmlString(
            $"<p><strong>Password Requirements:</strong></p>{Environment.NewLine}<p>Password must be at least 7 characters long.<br />"
                + "Password must include at least one number.</p>"
        );
    }
}
