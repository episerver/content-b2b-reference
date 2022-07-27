namespace Sample.Services.DashBoardPanel;

public interface ISharedService
{
    Task<DashboardPanelsResult> GetDashboardPanels();
}
