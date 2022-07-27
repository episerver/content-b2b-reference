namespace Sample.Models.ViewModels;

public class ShipToViewModel
{
    public bool IsNew { get; set; }
    public bool OneTimeAddress { get; set; }
    public string Label { get; set; }
    public CustomerValidationDto Validation { get; set; }
    public bool IsDefault { get; set; }
    public string Id { get; set; }
    public string CustomerNumber { get; set; }
    public string CustomerSequence { get; set; }
    public string CustomerName { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/FirstName")]
    public string FirstName { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/LastName")]
    public string LastName { get; set; }

    public string ContactFullName { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/CompanyName")]
    public string CompanyName { get; set; }

    public string Attention { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/Address1")]
    public string Address1 { get; set; }

    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/City")]
    public string City { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/PostalCode")]
    public string PostalCode { get; set; }

    [LocalizedRequiredIf("/Addresses/Form/Empty/State", "Country", "US")]
    public State State { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/Country")]
    public Country Country { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/Phone")]
    [LocalizedPhoneNumberFormat("/Addresses/Form/Error/InvalidPhoneNumber")]
    public string Phone { get; set; }

    public string FullAddress { get; set; }

    [LocalizedRequired("/Addresses/Form/Empty/Email")]
    [LocalizedEmail("/Addresses/Form/Error/InvalidEmail")]
    public string Email { get; set; }

    public string Fax { get; set; }
    public string CountryId { get; set; }
    public string StateId { get; set; }
}