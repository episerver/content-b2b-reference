namespace Sample.Models.Blocks;

[ContentType(
    DisplayName = "Recent Orders Block",
    GUID = "0d31d69b-6216-45e3-bbf0-2a30ab129b5c",
    Description = "Recent Orders",
    GroupName = Global.GroupNames.CommerceBlocks
)]
[SiteImageUrl]
public class RecentOrdersBlock : SiteBlockData
{
    [CultureSpecific]
    [Display(Name = "Recent Orders Text", Order = 1, GroupName = Global.GroupNames.Labels)]
    public virtual string RecentOrdersText { get; set; }

    [CultureSpecific]
    [Display(Name = "View All Button Text", Order = 2, GroupName = Global.GroupNames.Labels)]
    public virtual string ViewAllButtonText { get; set; }

    [Display(Name = "View All Link", Order = 3, GroupName = SystemTabNames.Content)]
    public virtual Url ViewAllLink { get; set; }

    [Display(Name = "Page Size", Order = 4, GroupName = SystemTabNames.Content)]
    [Range(5, 1000)]
    public virtual int PageSize { get; set; }

    [Display(Name = "Order Details Link", GroupName = SystemTabNames.Content, Order = 5)]
    public virtual Url OrderDetailsLink { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Date", GroupName = Global.GroupNames.Labels, Order = 6)]
    public virtual string HeaderDate { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Order#", GroupName = Global.GroupNames.Labels, Order = 7)]
    public virtual string HeaderOrderNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header ShipTo", GroupName = Global.GroupNames.Labels, Order = 8)]
    public virtual string HeaderShipTo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Status", GroupName = Global.GroupNames.Labels, Order = 9)]
    public virtual string HeaderStatus { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Web Order#", GroupName = Global.GroupNames.Labels, Order = 10)]
    public virtual string HeaderWebOrderNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header PO#", GroupName = Global.GroupNames.Labels, Order = 11)]
    public virtual string HeaderPoNo { get; set; }

    [CultureSpecific]
    [Display(Name = "Header Total", GroupName = Global.GroupNames.Labels, Order = 12)]
    public virtual string HeaderTotal { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        RecentOrdersText = "Recent Orders";
        ViewAllButtonText = "View All";
        PageSize = 5;
        HeaderDate = "Date";
        HeaderOrderNo = "Order #";
        HeaderShipTo = "Ship To / Pick Up";
        HeaderStatus = "Status";
        HeaderWebOrderNo = "Web Order #";
        HeaderPoNo = "PO #";
        HeaderTotal = "Total";
    }
}
