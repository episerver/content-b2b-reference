﻿namespace Sample.Models.ViewModels;

public class ProductViewModel
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string CustomerName { get; set; }
    public virtual string ShortDescription { get; set; }
    public virtual string ERPNumber { get; set; }
    public virtual string ERPDescription { get; set; }
    public virtual string UrlSegment { get; set; }
    public virtual Decimal BasicListPrice { get; set; }
    public virtual Decimal BasicSalePrice { get; set; }
    public virtual DateTime? BasicSaleStartDate { get; set; }
    public virtual DateTime? BasicSaleEndDate { get; set; }
    public virtual string SmallImagePath { get; set; }
    public virtual string MediumImagePath { get; set; }
    public virtual string LargeImagePath { get; set; }
    public virtual Decimal QtyOnHand { get; set; }
    public virtual bool IsConfigured { get; set; }
    public virtual bool IsFixedConfiguration { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual bool IsHazardousGood { get; set; }
    public virtual bool IsDiscontinued { get; set; }
    public virtual bool IsSpecialOrder { get; set; }
    public virtual bool IsGiftCard { get; set; }
    public virtual bool IsBeingCompared { get; set; }
    public virtual bool IsSponsored { get; set; }
    public virtual bool QuoteRequired { get; set; }
    public virtual string ManufacturerItem { get; set; }
    public virtual string PackDescription { get; set; }
    public virtual string AltText { get; set; }
    public virtual string CustomerUnitOfMeasure { get; set; }
    public virtual bool CanBackOrder { get; set; }
    public virtual bool TrackInventory { get; set; }
    public virtual int MultipleSaleQty { get; set; }
    public virtual string HtmlContent { get; set; }
    public virtual string ProductCode { get; set; }
    public virtual string PriceCode { get; set; }
    public virtual string Sku { get; set; }
    public virtual string UPCCode { get; set; }
    public virtual string ModelNumber { get; set; }
    public virtual string TaxCode1 { get; set; }
    public virtual string TaxCode2 { get; set; }
    public virtual string TaxCategory { get; set; }
    public virtual string ShippingClassification { get; set; }
    public virtual string ShippingLength { get; set; }
    public virtual string ShippingWidth { get; set; }
    public virtual string ShippingHeight { get; set; }
    public virtual string ShippingWeight { get; set; }
    public virtual Decimal QtyPerShippingPackage { get; set; }
    public virtual Decimal? ShippingAmountOverride { get; set; }
    public virtual Decimal? HandlingAmountOverride { get; set; }
    public virtual string MetaDescription { get; set; }
    public virtual string MetaKeywords { get; set; }
    public virtual string PageTitle { get; set; }
    public virtual bool AllowAnyGiftCardAmount { get; set; }
    public virtual int SortOrder { get; set; }
    public virtual bool HasMsds { get; set; }
    public virtual string Unspsc { get; set; }
    public virtual string RoundingRule { get; set; }
    public virtual string VendorNumber { get; set; }
    public virtual string UnitOfMeasure { get; set; }
    public virtual string UnitOfMeasureDisplay { get; set; }
    public virtual string SelectedUnitOfMeasure { get; set; }
    public virtual string SelectedUnitOfMeasureDisplay { get; set; }
    public virtual string ProductDetailUrl { get; set; }
    public virtual bool CanAddToCart { get; set; }
    public virtual bool AllowedAddToCart { get; set; }
    public virtual bool CanAddToWishlist { get; set; }
    public virtual bool CanViewDetails { get; set; }
    public virtual bool CanShowPrice { get; set; }
    public virtual bool CanShowUnitOfMeasure { get; set; }
    public virtual bool CanEnterQuantity { get; set; }
    public virtual bool CanConfigure { get; set; }
    public virtual bool IsStyleProductParent { get; set; }
    public virtual Decimal NumberInCart { get; set; }
    public virtual Decimal QtyOrdered { get; set; }
    public virtual double Score { get; set; }
    public virtual int SearchBoost { get; set; }
    public virtual List<UnitOfMeasureViewModel> AlternateUom { get; set; }
    public virtual ICollection<AttributeType> Attributes { get; set; }
    public virtual string Availability { get; set; }
    public virtual bool CanShowAvailability { get; set; }
}