namespace Sample.Models.Pages;

[SiteContentType(
    GroupName = Global.GroupNames.CommercePages,
    DisplayName = "My Account Page",
    GUID = "b2b7362f-0d2a-45df-8704-8c4d222413fc",
    Description = "My Account Dashboard"
)]
[SiteImageUrl]
[AvailableContentTypes(
    EPiServer.DataAbstraction.Availability.Specific,
    Include = new[]
    {
        typeof(AddressesPage),
        typeof(LoginPage),
        typeof(LogoutPage),
        typeof(CreateAccountPage),
        typeof(ChangePasswordPage),
        typeof(ForgotPasswordPage),
        typeof(ResetPasswordPage),
        typeof(OrderHistoryPage),
        typeof(InvoiceHistoryPage),
        typeof(SavedOrdersPage),
        typeof(WishListPage)
    }
)]
public class MyAccountPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Quick Link Heading", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string QuickLinkHeading { get; set; }

    [CultureSpecific]
    [Display(Name = "Dashboard Title", Order = 3, GroupName = Global.GroupNames.Labels)]
    public virtual string DashboardTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "My Lists Heading", Order = 4, GroupName = Global.GroupNames.Labels)]
    public virtual string MyListsHeading { get; set; }

    [Display(Name = "My List Link", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual Url MyListLink { get; set; }

    [Display(Name = "Orders History Link", GroupName = SystemTabNames.Content, Order = 6)]
    public virtual Url OrderHistoryLink { get; set; }

    [Display(Name = "Invoice History Link", GroupName = SystemTabNames.Content, Order = 7)]
    public virtual Url InvoiceHistoryLink { get; set; }

    [Display(Name = "Addresses Link", GroupName = SystemTabNames.Content, Order = 8)]
    public virtual Url AddressesLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Approval", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string OrderApproval { get; set; }

    [Display(Name = "Order Approval Link", GroupName = SystemTabNames.Content, Order = 10)]
    public virtual Url OrderApprovalLink { get; set; }

    [Display(Name = "Saved Orders Link", GroupName = SystemTabNames.Content, Order = 11)]
    public virtual Url SavedOrdersLink { get; set; }

    [Display(Name = "Wishlists Link", GroupName = SystemTabNames.Content, Order = 12)]
    public virtual Url WishlistsLink { get; set; }

    [Display(Name = "Account Settings Link", GroupName = SystemTabNames.Content, Order = 13)]
    public virtual Url AccountSettingsLink { get; set; }

    [Display(
        Name = "Recent Orders Content Area",
        GroupName = SystemTabNames.Content,
        Order = 14
    )]
    [AllowedTypes(new[] { typeof(RecentOrdersBlock) })]
    public virtual ContentArea RecentOrdersContentArea { get; set; }

    [Display(Name = "Quick Links Content Area", GroupName = SystemTabNames.Content, Order = 15)]
    [AllowedTypes(new[] { typeof(QuickLinksBlock) })]
    public virtual ContentArea QuickLinksContentArea { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "My Account";
        QuickLinkHeading = "Quick Link";
        DashboardTitle = "Dashboard";
        MyListsHeading = "My Lists";
        OrderApproval = "Order Approval";
    }
}
