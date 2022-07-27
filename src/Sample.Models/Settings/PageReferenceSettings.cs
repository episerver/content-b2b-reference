namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Page Reference Settings",
    GUID = "f3a631ab-9462-438c-8b52-940e8ad570f9",
    Description = "Page Reference Settings",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Page Reference Settings"
)]
[SiteImageUrl]
public class PageReferenceSettings : SettingsBase
{
    [Display(Name = "Terms page", GroupName = Global.GroupNames.SiteSettings, Order = 250)]
    public virtual PageReference TermsPage { get; set; }

    [Display(Name = "Privacy page", GroupName = Global.GroupNames.SiteSettings, Order = 250)]
    public virtual PageReference PrivacyPage { get; set; }

    [Display(Name = "Search page", GroupName = Global.GroupNames.SiteSettings, Order = 460)]
    public virtual PageReference SearchPage { get; set; }

    [Display(Name = "Product page", GroupName = Global.GroupNames.SiteSettings, Order = 10)]
    public virtual PageReference ProductPage { get; set; }

    [Display(Name = "Catalog page", GroupName = Global.GroupNames.SiteSettings, Order = 20)]
    public virtual PageReference CatalogPage { get; set; }

    [Display(Name = "Brands listing page",  GroupName = Global.GroupNames.SiteSettings, Order = 30)]
    public virtual PageReference BrandsPage { get; set; }

    [Display(Name = "Brand detail page", GroupName = Global.GroupNames.SiteSettings, Order = 35)]
    public virtual PageReference BrandsDetailPage { get; set; }

    [Display(Name = "Addresses Page", GroupName = Global.GroupNames.SiteSettings, Order = 40)]
    public virtual PageReference AddresesPage { get; set; }

    [Display(Name = "Login Page", GroupName = Global.GroupNames.SiteSettings, Order =  50)]
    public virtual PageReference LoginPage { get; set; }

    [Display(Name = "Logout Page", GroupName = Global.GroupNames.SiteSettings, Order = 55)]
    public virtual PageReference LogoutPage { get; set; }

    [Display(Name = "Cart Page", GroupName = Global.GroupNames.SiteSettings, Order = 60)]
    public virtual PageReference CartPage { get; set; }

    [Display(Name = "Wishlist Page", GroupName = Global.GroupNames.SiteSettings, Order = 70)]
    public virtual PageReference WishlistPage { get; set; }

    [Display(Name = "Product Compare Page", GroupName = Global.GroupNames.SiteSettings, Order = 80)]
    public virtual PageReference ComparePage { get; set; }

    [Display(Name = "Reegister Page", GroupName = Global.GroupNames.SiteSettings, Order = 90)]
    public virtual PageReference RegisterPage { get; set; }

    [Display(Name = "Forgot password Page", GroupName = Global.GroupNames.SiteSettings, Order = 100)]
    public virtual PageReference ForgotPasswordPage { get; set; }

    [Display(Name = "My account Page", GroupName = Global.GroupNames.SiteSettings, Order = 110)]
    public virtual PageReference MyAccountPage { get; set; }

    [Display(Name = "Checkout Page", GroupName = Global.GroupNames.SiteSettings, Order = 120)]
    public virtual PageReference ChecoutPage { get; set; }

    [Display(Name = "Order Confirmation Page", GroupName = Global.GroupNames.SiteSettings, Order = 130)]
    public virtual PageReference OrderConfirmationPage { get; set; }

    [Display(Name = "Change Password Page", GroupName = Global.GroupNames.SiteSettings, Order = 140)]
    public virtual PageReference ChangePasswordPage { get; set; }

    [Display(Name = "Invoice listing page", GroupName = Global.GroupNames.SiteSettings, Order = 150)]
    public virtual PageReference InvoiceListingPage { get; set; }

    [Display(Name = "Invoice Detail Page", GroupName = Global.GroupNames.SiteSettings, Order = 160)]
    public virtual PageReference InvoiceDetailPage { get; set; }

    [Display(Name = "Order Listing Page", GroupName = Global.GroupNames.SiteSettings, Order = 150)]
    public virtual PageReference OrderListingPage { get; set; }

    [Display(Name = "Order Detail Page", GroupName = Global.GroupNames.SiteSettings, Order = 160)]
    public virtual PageReference OrderDetailPage { get; set; }

    [Display(Name = "Quick Order Page", GroupName = Global.GroupNames.SiteSettings, Order = 170)]
    public virtual PageReference OrderistingPage { get; set; }

    [Display(Name = "Quick Order Upload Page", GroupName = Global.GroupNames.SiteSettings, Order = 180)]
    public virtual PageReference QuickOrderUploadPage { get; set; }

    [Display(Name = "Saved Orders Page", GroupName = Global.GroupNames.SiteSettings, Order = 150)]
    public virtual PageReference SavedOrdersPage { get; set; }

    [Display(Name = "Saved Orders Detail Page", GroupName = Global.GroupNames.SiteSettings, Order = 160)]
    public virtual PageReference SavedOrderDetailPage { get; set; }

    [Display(Name = "Return Request Page", GroupName = Global.GroupNames.SiteSettings, Order = 160)]
    public virtual PageReference ReturnRequestPage { get; set; }
}
