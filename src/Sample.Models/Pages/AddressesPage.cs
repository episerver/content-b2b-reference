namespace Sample.Models.Pages;

[SiteContentType(
    GroupName = Global.GroupNames.CommercePages,
    DisplayName = "Address Page",
    GUID = "15F570D6-CA94-4887-BC83-61B86582EB7B",
    Description = "Address Page"
)]
[SiteImageUrl]
[AvailableContentTypes(EPiServer.DataAbstraction.Availability.None)]
public class AddressesPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Save Button Label", GroupName = Global.GroupNames.Labels, Order = 1)]
    public virtual string SaveButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Back Button Label", GroupName = Global.GroupNames.Labels, Order = 1)]
    public virtual string BackButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "New Address Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string NewAddressLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Edit Address Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string EditAddressLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Address Name Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string AddressNameLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Is Default Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string IsDefaultLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Company Name Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string CompanyNameLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Attention Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string AttentionLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Addreess 1 Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string Address1Label { get; set; }

    [CultureSpecific]
    [Display(Name = "Address 2 Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string Address2Label { get; set; }

    [CultureSpecific]
    [Display(Name = "Country Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string CountryLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Region Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string RegionLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "City Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string CityLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Postal Code Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string PostalCodeLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Email Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string EmailLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Phone Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string PhoneLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Bill To Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string BillToLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Edit Bill To Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string EditBillToLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Ship To Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ShipToLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Items Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ItemsLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Previous Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string PreviousLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Next Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string NextLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string SearchLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Search placeholder Label", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string SearchPlaceholderLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        Address1Label = "Address 1";
        Address2Label = "Address 2";
        AddressNameLabel = "Address Label";
        AttentionLabel = "Attention";
        BackButtonLabel = "Back";
        BillToLabel = "Bill To";
        CityLabel = "City";
        CompanyNameLabel = "Company Name";
        CountryLabel = "Country";
        EditAddressLabel = "Edit Address";
        EditBillToLabel = "Edit Bill To";
        EmailLabel = "Email";
        IsDefaultLabel = "Is Default";
        ItemsLabel = " items";
        MetaTitle = "Addresses";
        NewAddressLabel = "New Address";
        NextLabel = "Next";
        PhoneLabel = "Phone";
        PostalCodeLabel = "Postal Code";
        PreviousLabel = "Previous";
        RegionLabel = "Region / State";
        SaveButtonLabel = "Save";
        SearchLabel = "Search";
        SearchPlaceholderLabel = "Search ship to";
    }
}
