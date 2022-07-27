namespace Sample.Models.Settings;

[SettingsContentType(
    DisplayName = "Labels Settings",
    GUID = "0CE338DE-8A53-4086-9AA4-C49B95E4FB82",
    GroupName = Global.GroupNames.SiteSettings,
    SettingsName = "Label Settings"
)]
[SiteImageUrl]
public class LabelSettings : SettingsBase
{
    [CultureSpecific]
    [Display(Name = "UOM Label", GroupName = SystemTabNames.Content, Order = 1)]
    public virtual string UomLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Qty Label", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string QtyLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Cart Button Caption", GroupName = SystemTabNames.Content, Order = 3)]
    public virtual string AddToCartButtonCaption { get; set; }

    [CultureSpecific]
    [Display(Name = "Terms text", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string TermsText { get; set; }

    [CultureSpecific]
    [Display(Name = "Privacy Text", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string PrivacyText { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Cart Pop Up CartConfirmation Title", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string AddToCartPopUpConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Cart Pop Up CartConfirmation Message", GroupName = SystemTabNames.Content, Order = 6)]
    public virtual string AddToCartPopUpConfirmationMessage { get; set; }

    [Display(Name = "Enable Add To Cart Pop Up ", GroupName = SystemTabNames.Content, Order = 7)]
    public virtual bool EnableAddToCartPopUp { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Button Caption", GroupName = SystemTabNames.Content, Order = 8)]
    public virtual string AddToWishListButtonCaption { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Pop Up CartConfirmation Title", GroupName = SystemTabNames.Content, Order = 10)]
    public virtual string AddToWishListPopUpConfirmationTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Pop Up CartConfirmation Message", GroupName = SystemTabNames.Content, Order = 11)]
    public virtual string AddToWishListPopUpConfirmationMessage { get; set; }

    [Display(Name = "Enable Add To Wish List Pop Up ", GroupName = SystemTabNames.Content, Order = 12)]
    public virtual bool EnableAddToWishListPopUp { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Pop Up dropdown label", GroupName = SystemTabNames.Content, Order = 13)]
    public virtual string AddToWishListPopUpDropdownLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Pop Up New Wish List label", GroupName = SystemTabNames.Content, Order = 14)]
    public virtual string AddToWishListPopUpNewWishListLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List Pop Up Drop down Value", GroupName = SystemTabNames.Content, Order = 15)]
    public virtual string AddToWishListPopUpDropdownValue { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To WishList PopUp Same Name Validation Error", GroupName = SystemTabNames.Content, Order = 16)]
    public virtual string AddToWishListPopUpSameNameValidationError { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To WishList PopUp Success Message", GroupName = SystemTabNames.Content, Order = 17)]
    public virtual string AddToWishListPopUpSuccessMessage { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To Wish List PopUp Item Exist Validation Error", GroupName = SystemTabNames.Content, Order = 18)]
    public virtual string AddToWishListPopUpItemExistValidationError { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To WishList PopUp AddTo List Button Label", GroupName = SystemTabNames.Content, Order = 19)]
    public virtual string AddToWishListPopUpAddToListButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Add To WishList PopUp Cancel Button Label", GroupName = SystemTabNames.Content, Order = 20)]
    public virtual string AddToWishListPopUpCancelButtonLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "WishList Email Remainder CheckBox Label", GroupName = SystemTabNames.Content,Order = 21)]
    public virtual string WishListEmailRemainderCheckBoxLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "WishList Popup SignIn", GroupName = SystemTabNames.Content, Order = 22)]
    public virtual string WishListPopupSignIn { get; set; }

    [CultureSpecific]
    [Display(Name = "Or label", GroupName = SystemTabNames.Content, Order = 24)]
    public virtual string OrLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Login Text", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string LoginText { get; set; }

    [CultureSpecific]
    [Display(Name = "Cart Text", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string CartText { get; set; }

    [CultureSpecific]
    [Display(Name = "Customer Name Label", GroupName = SystemTabNames.Content)]
    public virtual string CustomerNameLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Bill To Label", GroupName = SystemTabNames.Content)]
    public virtual string BillToLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Ship To Label", GroupName = SystemTabNames.Content)]
    public virtual string ShipToLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Checkout Label", GroupName = SystemTabNames.Content)]
    public virtual string CheckoutLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Back to Cart Label", GroupName = SystemTabNames.Content)]
    public virtual string BackToCartLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Guest Checkout Label", GroupName = SystemTabNames.Content)]
    public virtual string GuestCheckoutLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Login Link Text", GroupName = SystemTabNames.Content)]
    public virtual string LoginLinkText { get; set; }

    [CultureSpecific]
    [Display(Name = "Logout Link Text", GroupName = SystemTabNames.Content)]
    public virtual string LogoutLinkText { get; set; }

    [CultureSpecific]
    [Display(Name = "Customer Change Link Text", GroupName = SystemTabNames.Content)]
    public virtual string CustomerChangeLinkText { get; set; }

    [CultureSpecific]
    [Display(Name = "My Comparison List Text", GroupName = SystemTabNames.Content, Order = 1)]
    public virtual string MyComparisonListText { get; set; }

    [CultureSpecific]
    [Display(Name = "Compare Button Text", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string CompareButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Clear All Button Text", GroupName = SystemTabNames.Content, Order = 3)]
    public virtual string ClearAllButtonText { get; set; }

    [CultureSpecific]
    [Display(Name = "Comparison Message", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string ComparisonMessage { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Box Placeholder Text", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string SearchPlaceholderText { get; set; }

    [CultureSpecific]
    [Display(Name = "Search Button Tooltip Text", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual string SearchButtonTooltipText { get; set; }

    [CultureSpecific]
    [Display(Name = "Register Text", GroupName = SystemTabNames.Content, Order = 7)]
    public virtual string RegisterText { get; set; }

    [CultureSpecific]
    [Display(Name = "SignIn Text", GroupName = SystemTabNames.Content, Order = 4)]
    public virtual string SignInText { get; set; }

    [CultureSpecific]
    [Display(Name = "Forget Password Text", GroupName = SystemTabNames.Content, Order = 2)]
    public virtual string ForgetPasswordText { get; set; }

    [CultureSpecific]
    [Display(Name = "SignOut Text", GroupName = SystemTabNames.Content, Order = 9)]
    public virtual string SignOutText { get; set; }

    [CultureSpecific]
    [Display(Name = "Forget Password Label", GroupName = SystemTabNames.Content)]
    public virtual string ForgetPasswordLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "My Account Label", GroupName = SystemTabNames.Content)]
    public virtual string MyAcountLabel { get; set; }

    [CultureSpecific]
    [Display(Name = "Change Password Label", GroupName = SystemTabNames.Content)]
    public virtual string ChangePasswordLabel { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        UomLabel = "UOM";
        QtyLabel = "Qty";
        AddToCartButtonCaption = "Add To Cart";
        AddToCartPopUpConfirmationTitle = "Item added to cart";
        AddToCartPopUpConfirmationMessage = "The requested product has been added to the cart";
        EnableAddToCartPopUp = true;
        AddToWishListButtonCaption = "Add To List";
        AddToWishListPopUpConfirmationTitle = "Add To List";
        AddToWishListPopUpConfirmationMessage = "Item has been added to Wish List";
        EnableAddToWishListPopUp = true;
        AddToWishListPopUpDropdownLabel = "Select Wish List";
        AddToWishListPopUpNewWishListLabel = "Create New";
        AddToWishListPopUpDropdownValue = "Create New List";
        AddToWishListPopUpSameNameValidationError =
            "Select a list or enter a new wish list name";
        AddToWishListPopUpSuccessMessage = "Item has been added";
        AddToWishListPopUpItemExistValidationError = "Item already exists";
        OrLabel = "- OR -";
        LoginLinkText = "SignIn";
        LogoutLinkText = "SignOut";
        CustomerChangeLinkText = "Change Customer";
        CustomerNameLabel = "Cust #";
        ForgetPasswordLabel = "Forgor Password";
        MyAcountLabel = "My Account";
        ChangePasswordLabel = "Change Password";
        BillToLabel = "Bill to";
        ShipToLabel = "Ship to";
        CheckoutLabel = "Secure Checkout";
        BackToCartLabel = "Back to Cart";
        MyComparisonListText = "My Comparison List";
        CompareButtonText = "Compare";
        ClearAllButtonText = "Clear All";
        ComparisonMessage = "Too many items selected for comparison";
        SearchPlaceholderText = "Enter keyword or item #";
        SearchButtonTooltipText = "";
        ForgetPasswordText = "Forget Password?";
        SignInText = "Sign In";
        RegisterText = "Register";
        SignOutText = "Sign Out";
    }
}
