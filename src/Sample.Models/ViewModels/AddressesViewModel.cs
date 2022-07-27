using CommerceApiSDK.Models.Parameters;
using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class AddressesViewModel : ContentViewModel<AddressesPage>
{
    public AddressesViewModel()
    {

    }

    public AddressesViewModel(AddressesPage currentPage) : base(currentPage)
    {
    }

    public ShipTosQueryParameters ShipTosQueryParameters { get; set; }
    public GetBillTosResult BillTos { get; set; }
    public GetShipTosResult ShipTos { get; set; }
    public Session Session { get; set; }
    public BillTo BillTo { get; set; }
    public ShipTo ShipTo { get; set; }
    public bool IsBillTo { get; set; }
    public bool IsNew { get; set; }
    public string BIllToId { get; set; }
}

public class ChangeCustomer
{
    public string BillTo { get; set; }

    public string ShipTo { get; set; }

    public string FulfillmentMethod { get; set; }

    public string Warehouse { get; set; }
}

public class SaveAddress
{
    public string Label { get; set; }

    public string CompanyName { get; set; }

    public string Attention { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string PostalCode { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public bool IsDefault { get;set; }

    public string BillToId { get; set; }

    public string ShipToId { get; set; }
}