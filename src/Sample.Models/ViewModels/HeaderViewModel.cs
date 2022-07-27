using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class HeaderViewModel
{
    public Url Logo { get; set; }

    public string Title { get; set; }

    public PageReference LoginPage { get; set; }

    public PageReference CartPage { get; set; }

    public PageReference ChangePasswordPage { get; set; }

    public PageReference ForgotPasswordPage { get; set; }

    public PageReference MyAccountPage { get; set; }

    public PageReference SignoutPage { get; set; }

    public string LoginText { get; set; }

    public string CartText { get; set; }

    public string ChangeCustomerText { get; set; }

    public string MyAccountText { get; set; }

    public string ChangePasswordText { get; set; }

    public string ForgotPasswordText { get; set; }

    public string CustomerNumberText { get; set; }

    public string SingoutText { get; set; }

    public bool IsAuthenticated { get; set; }

    public string CurrentUrl {get;set;}

    public Session Session { get; set; }

    public Website Website { get; set; }

    public int CartCount { get; set; }

    public List<Warehouse> Warehouses { get; set; }
}
