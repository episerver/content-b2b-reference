namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Change Password Page",
    GUID = "f1035cfa-028e-484c-8e5b-5597305a20ab",
    GroupName = Global.GroupNames.CommercePages,
    Description = "To Change New Password"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class ChangePasswordPage : BasePage
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
        GroupName = SystemTabNames.Content,
        Order = 3
    )]
    public virtual XhtmlString Instruction { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Button Text",
        Description = "Button Text",
        GroupName = Global.GroupNames.Labels,
        Order = 4
    )]
    public virtual string ButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Cancel  Text", Order = 5, GroupName = Global.GroupNames.Labels)]
    public virtual string CancelText { get; set; }

    [Display(Name = "Cancel Link", Order = 6, GroupName = SystemTabNames.Content)]
    public virtual Url CancelLink { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Sub Title",
        Description = "Title",
        GroupName = Global.GroupNames.Labels,
        Order = 7
    )]
    public virtual string SubTitle { get; set; }

    [Display(
        Name = "Change Password Redirect Url",
        Order = 8,
        GroupName = SystemTabNames.Content
    )]
    public virtual Url ChangePasswordRedirectUrl { get; set; }

    [CultureSpecific]
    [Display(Name = "Current Password", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string CurrentPasswordLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "New Password", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string NewPasswordLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Confirm Password", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string ConfirmPasswordLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Change Password";
        RequiredMessage = "Required*";
        Instruction = new XhtmlString(
            $"<p><strong>Password Requirements:</strong></p>{Environment.NewLine}<p>Password must be at least 7 characters long.<br />"
                + "Password must include at least one number.</p>"
        );
        ButtonText = "Submit";
        CancelText = "Cancel";
        SubTitle = "Enter your new password.";
        CurrentPasswordLabel = "Current Password";
        NewPasswordLabel = "New Password";
        ConfirmPasswordLabel = "Confirm Password";
    }
}
