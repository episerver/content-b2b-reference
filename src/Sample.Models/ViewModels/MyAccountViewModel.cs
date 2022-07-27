using CommerceApiSDK.Models.Results;

namespace Sample.Models.ViewModels;

public class MyAccountViewModel
{
    public IList<WishList> WishListCollection { get; set; }
    public DashboardPanelsResult DashBoardPanelCollection { get; set; }
    public string MyListLink { get; set; }
    public string OrderApprovalLink { get; set; }
    public List<QuickLinksModel> QuickLinks { get; set; }
}