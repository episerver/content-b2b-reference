namespace Sample.Models.ViewModels;

public class ReviewAndSubmitViewModel
{
    public string CarrierId { get; set; }

    public string ServiceId { get; set; }

    public string PaymentMethodId { get; set; }

    public string DeliveryDate { get; set; }

    public string PONumber { get; set; }

    public bool SaveCard { get; set; }

    public string NameOnCard { get; set; }

    public string ExpirationDate { get; set; }

    public bool UseBillingAddress { get; set; }

    public string Address1 { get; set; }

    public string CountryId { get; set; }

    public string RegionId { get; set; }

    public string PostalCode { get; set; }

    public string City { get; set; }

    public string CardToken { get; set; }

    public string CvvToken { get; set; }

    public string CardType { get; set; }
}
