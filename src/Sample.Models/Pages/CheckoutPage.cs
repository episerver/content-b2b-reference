namespace Sample.Models.Pages;

[SiteContentType(
    DisplayName = "Checkout Page",
    GroupName = Global.GroupNames.CommercePages,
    GUID = "b32b4ca2-a97d-47b5-9e88-aad74d7c0e0b",
    Description = "To Create Checkout Page"
)]
[SiteImageUrl]
[AvailableContentTypes(
    EPiServer.DataAbstraction.Availability.Specific,
    Include = new[] { typeof(OrderConfirmationPage) }
)]
public class CheckoutPage : BasePage
{
    [CultureSpecific]
    [Display(Name = "Shipping Method Subtitle", GroupName = Global.GroupNames.Labels, Order = 2)]
    public virtual string ShippingMethodSubtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Select Carrier Text", GroupName = Global.GroupNames.Labels, Order = 3)]
    public virtual string SelectCarrier { get; set; }

    [CultureSpecific]
    [Display(Name = "Select Service Text", GroupName = Global.GroupNames.Labels, Order = 4)]
    public virtual string SelectService { get; set; }

    [CultureSpecific]
    [Display(Name = "Continue Button Text", GroupName = Global.GroupNames.Labels, Order = 5)]
    public virtual string ContinueButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Delivery Date Text", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string DeliveryDateText { get; set; }

    [CultureSpecific]
    [Display(Name = "Delivery Date Info", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string DeliveryDateInfo { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Notes Text", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string OrderNotesText { get; set; }

    [CultureSpecific]
    [Display(Name = "Place Order Button Text", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string PlaceOrderButtonText { get; set; }

    [Display(Name = "Order Confirmation Link", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual Url OrderConfirmationUrl { get; set; }

    [CultureSpecific]
    [Display(Name = "No Shipping Method", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string NoShippingMethodText { get; set; }

    [CultureSpecific]
    [Display(Name = "Payment Details Subtitle", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string PaymentDetailsSubtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Payment Method", GroupName = Global.GroupNames.Labels, Order = 13)]
    public virtual string PaymentMethod { get; set; }

    [CultureSpecific]
    [Display(Name = "PO Number", GroupName = Global.GroupNames.Labels, Order = 14)]
    public virtual string PoNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Card Type", GroupName = Global.GroupNames.Labels, Order = 15)]
    public virtual string CardType { get; set; }

    [CultureSpecific]
    [Display(Name = "Name on Card", GroupName = Global.GroupNames.Labels, Order = 16)]
    public virtual string NameOnCard { get; set; }

    [CultureSpecific]
    [Display(Name = "Card Number", GroupName = Global.GroupNames.Labels, Order = 17)]
    public virtual string CardNumber { get; set; }

    [CultureSpecific]
    [Display(Name = "Security Code", GroupName = Global.GroupNames.Labels, Order = 18)]
    public virtual string SecurityCode { get; set; }

    [CultureSpecific]
    [Display(Name = "Expiration Date", GroupName = Global.GroupNames.Labels, Order = 19)]
    public virtual string ExpirationDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Credit Card Address", GroupName = Global.GroupNames.Labels, Order = 20)]
    public virtual string CreditCardAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Use Billing Address", GroupName = Global.GroupNames.Labels, Order = 21)]
    public virtual string UseBillingAddress { get; set; }

    [CultureSpecific]
    [Display(Name = "Address", GroupName = Global.GroupNames.Labels, Order = 22)]
    public virtual string Address { get; set; }

    [CultureSpecific]
    [Display(Name = "Country", GroupName = Global.GroupNames.Labels, Order = 23)]
    public virtual string Country { get; set; }

    [CultureSpecific]
    [Display(Name = "City", GroupName = Global.GroupNames.Labels, Order = 24)]
    public virtual string City { get; set; }

    [CultureSpecific]
    [Display(Name = "Postal Code", GroupName = Global.GroupNames.Labels, Order = 25)]
    public virtual string PostalCode { get; set; }

    [CultureSpecific]
    [Display(Name = "Promotion Code", GroupName = Global.GroupNames.Labels, Order = 26)]
    public virtual string PromotionCode { get; set; }

    [CultureSpecific]
    [Display(Name = "Apply Button", GroupName = Global.GroupNames.Labels, Order = 27)]
    public virtual string ApplyButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "State", GroupName = Global.GroupNames.Labels, Order = 28)]
    public virtual string State { get; set; }

    [CultureSpecific]
    [Display(Name = "Order Summary Subtitle", GroupName = Global.GroupNames.Labels, Order = 29)]
    public virtual string OrderSummarySubtitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Sub Total", GroupName = Global.GroupNames.Labels, Order = 30)]
    public virtual string Subtotal { get; set; }

    [CultureSpecific]
    [Display(Name = "Tax", GroupName = Global.GroupNames.Labels, Order = 31)]
    public virtual string Tax { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping & Handling", GroupName = Global.GroupNames.Labels, Order = 32)]
    public virtual string ShippingHandling { get; set; }

    [CultureSpecific]
    [Display(Name = "Total", GroupName = Global.GroupNames.Labels, Order = 33)]
    public virtual string Total { get; set; }

    [CultureSpecific]
    [Display(Name = "Billing Information", GroupName = Global.GroupNames.Labels, Order = 34)]
    public virtual string BillingInformation { get; set; }

    [CultureSpecific]
    [Display(Name = "Shipping Information", GroupName = Global.GroupNames.Labels, Order = 35)]
    public virtual string ShippingInformation { get; set; }

    [CultureSpecific]
    [Display(Name = "Edit Link Text", GroupName = Global.GroupNames.Labels, Order = 36)]
    public virtual string EditLinkText { get; set; }

    [Display(Name = "Edit Link Url", GroupName = SystemTabNames.Content, Order = 37)]
    public virtual Url EditLinkUrl { get; set; }

    [Display(Name = "SignIn Page Link", GroupName = SystemTabNames.Content, Order = 12)]
    public virtual Url SignInPageLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Company Label", GroupName = Global.GroupNames.Labels, Order = 38)]
    public virtual string CompanyLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Edit Billing Address Label",
        GroupName = Global.GroupNames.Labels,
        Order = 39
    )]
    public virtual string EditBillingAddressLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Change Bill To Customer Label",
        GroupName = Global.GroupNames.Labels,
        Order = 40
    )]
    public virtual string ChangeBillToCustomerLabel { get; set; }

    [Display(Name = "Change Customer URL", GroupName = Global.GroupNames.Labels, Order = 41)]
    public virtual Url ChangeCustomerUrl { get; set; }

    [CultureSpecific]
    [Display(Name = "Address2", GroupName = Global.GroupNames.Labels, Order = 42)]
    public virtual string Address2 { get; set; }

    [CultureSpecific]
    [Display(Name = "Phone", GroupName = Global.GroupNames.Labels, Order = 43)]
    public virtual string Phone { get; set; }

    [CultureSpecific]
    [Display(Name = "Email", GroupName = Global.GroupNames.Labels, Order = 44)]
    public virtual string Email { get; set; }

    [CultureSpecific]
    [Display(Name = "Attention", GroupName = Global.GroupNames.Labels, Order = 45)]
    public virtual string Attention { get; set; }

    [CultureSpecific]
    [Display(Name = "Required Field Message", GroupName = Global.GroupNames.Labels, Order = 46)]
    public virtual string RequiredFieldError { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Shipping and Delivery Title",
        GroupName = Global.GroupNames.Labels,
        Order = 47
    )]
    public virtual string ShippingandDeliveryTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Payment Details Title", GroupName = Global.GroupNames.Labels, Order = 48)]
    public virtual string PaymentDetailsTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Billing Address Description Label",
        GroupName = Global.GroupNames.Labels,
        Order = 49
    )]
    public virtual string BillingAddressDescriptionLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Change Shipping Address DropdownLabel",
        GroupName = Global.GroupNames.Labels,
        Order = 50
    )]
    public virtual string ChangeShippingAddressDropdownLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "ShipTo Description Label ",
        GroupName = Global.GroupNames.Labels,
        Order = 51
    )]
    public virtual string ShipToDescriptionLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Delivery Method Label ", GroupName = Global.GroupNames.Labels, Order = 52)]
    public virtual string DeliveryMethodLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Payment Description Label",
        GroupName = Global.GroupNames.Labels,
        Order = 53
    )]
    public virtual string PaymentDescriptionLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Choose Payment Method Label",
        GroupName = Global.GroupNames.Labels,
        Order = 54
    )]
    public virtual string ChoosePaymentMethodLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Save Card Label", GroupName = Global.GroupNames.Labels, Order = 55)]
    public virtual string SaveCardLabel { get; set; }

    [Display(Name = "CheckOutPage Url", GroupName = SystemTabNames.Content, Order = 56)]
    public virtual Url CheckOutPageUrl { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Use Shipping Address Label",
        GroupName = Global.GroupNames.Labels,
        Order = 57
    )]
    public virtual string UseShippingAddressLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Promotion Label",
        Description = "Promotion Label",
        GroupName = Global.GroupNames.Labels,
        Order = 58
    )]
    public virtual string PromotionLabel { get; set; }

    [Display(Name = "AddressPage Url", GroupName = SystemTabNames.Content, Order = 59)]
    public virtual Url AddressPageUrl { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Selection Required Label",
        Description = "Selection Required Label",
        GroupName = Global.GroupNames.Labels,
        Order = 59
    )]
    public virtual string SelectionRequiredLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Choose Carrier Label",
        Description = "Choose Carrier Label",
        GroupName = Global.GroupNames.Labels,
        Order = 60
    )]
    public virtual string ChooseCarrierLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Choose Service Label",
        Description = "Choose Service Label",
        GroupName = Global.GroupNames.Labels,
        Order = 61
    )]
    public virtual string ChooseServiceLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Order Review Label",
        Description = "Order Review Label",
        GroupName = Global.GroupNames.Labels,
        Order = 62
    )]
    public virtual string OrderReviewLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Company CO Label",
        Description = "Company CO Label",
        GroupName = Global.GroupNames.Labels,
        Order = 63
    )]
    public virtual string CompanyCo { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Credit Card Details Label",
        GroupName = Global.GroupNames.Labels,
        Order = 63
    )]
    public virtual string CreditCardDetailsLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Address1", GroupName = Global.GroupNames.Labels, Order = 64)]
    public virtual string Address1 { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Edit Shipping Address Label",
        GroupName = Global.GroupNames.Labels,
        Order = 65
    )]
    public virtual string EditShippingAddressLabel { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Phone Number Invalid Error",
        GroupName = Global.GroupNames.Labels,
        Order = 66
    )]
    public virtual string PhoneNumberInvalidError { get; set; }

    [CultureSpecific]
    [Display(Name = "Email Invalid Error", GroupName = Global.GroupNames.Labels, Order = 67)]
    public virtual string EmailInvalidError { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        MetaTitle = "Checkout";
        ShippingMethodSubtitle = "Shipping Method";
        SelectCarrier = "Select Carrier";
        SelectService = "Select Service";
        ContinueButtonText = "Continue";
        DeliveryDateText = "Request Delivery Date (optional)";
        DeliveryDateInfo = "This date is only a request and may not be fulfilled.";
        OrderNotesText = "Add Order Notes (optional):";
        PlaceOrderButtonText = "Place Order";
        PaymentDetailsSubtitle = "Payment Details";
        PaymentMethod = "Payment Method";
        PoNumber = "PO Number";
        CardType = "Card Type";
        NameOnCard = "Name on Card";
        CardNumber = "Card Number";
        SecurityCode = "Security Code";
        ExpirationDate = "Expiration Date";
        CreditCardAddress = "Credit Card Address";
        UseBillingAddress = "Use Billing Address";
        Address = "Address";
        Country = "Country";
        City = "City";
        PostalCode = "Postal Code";
        PromotionCode = "Have a Promotion Code?";
        ApplyButtonText = "Apply";
        State = "State";
        OrderSummarySubtitle = "Order Summary";
        Subtotal = "Order Sub Total";
        Tax = "Tax";
        ShippingHandling = "Shipping & Handling";
        Total = "Total";
        BillingInformation = "Payment Details";
        ShippingInformation = "Shipping and Delivery";
        EditLinkText = "Edit";
        CompanyLabel = "Company";
        EditBillingAddressLabel = "Edit";
        ChangeBillToCustomerLabel = "Change Customer";
        Address2 = "Address 2";
        Phone = "Phone";
        Email = "Email";
        Attention = "Attention";
        RequiredFieldError = "This field is required.";
        ShippingandDeliveryTitle = "Shipping & Delivery";
        PaymentDetailsTitle = "Payment Details";
        BillingAddressDescriptionLabel = "Billing Address";
        ChangeShippingAddressDropdownLabel = "Change Shipping Address";
        ShipToDescriptionLabel = "Ship To";
        DeliveryMethodLabel = "Delivery Method";
        PaymentDescriptionLabel = "Payment";
        ChoosePaymentMethodLabel = "Choose Payment Method";
        SaveCardLabel = "Save This Card";
        PromotionLabel = "Promo Applied";
        SelectionRequiredLabel = "[ Selection Required ]";
        ChooseCarrierLabel = "Choose Carrier";
        ChooseServiceLabel = "Choose Service";
        OrderReviewLabel = "Order Review";
        CompanyCo = "Company Name Or C/ O";
        Address1 = "Address 1";
        EditShippingAddressLabel = "Edit";
        PhoneNumberInvalidError = "Phone Number is not valid!";
        EmailInvalidError = "Email is not valid!";
        CreditCardDetailsLabel = "Credit Card Details";
    }
}
