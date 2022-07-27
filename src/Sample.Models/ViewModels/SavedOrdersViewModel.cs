using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class SavedOrdersViewModel
{
    public string ClearButtonLink { get; set; }
    public string SearchButtonLink { get; set; }
    public GetShipTosResult ShipToCollection { get; set; }
    public CartCollectionModel CartCollection { get; set; }
    public PaginationExtendedModel Pagination { get; set; }
}

public class CartCollectionParameter
{
    public virtual Guid? BillToId { get; set; }

    public virtual Guid? ShipToId { get; set; }

    public virtual string Status { get; set; }

    public virtual string OrderNumber { get; set; }

    public virtual DateTime? FromDate { get; set; }

    public virtual DateTime? ToDate { get; set; }

    public virtual string OrderTotalOperator { get; set; }

    public virtual Decimal OrderTotal { get; set; }

    public virtual int? Page { get; set; }

    public virtual int? PageSize { get; set; }

    public virtual string Sort { get; set; }

    public enum CartStatus
    {
        Saved,
    }
}