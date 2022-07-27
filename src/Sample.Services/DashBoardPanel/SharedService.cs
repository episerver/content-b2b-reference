using CommerceApiSDK.Services.Interfaces;

namespace Sample.Services.DashBoardPanel;

public class SharedService : BaseService, ISharedService
{
    private IDashboardPanelsService _dashboardPanelsService;

    public SharedService(IDashboardPanelsService dashboardPanelsService)
    {
        _dashboardPanelsService = dashboardPanelsService;
    }

    public async Task<DashboardPanelsResult> GetDashboardPanels()
    {
        return await _dashboardPanelsService.GetDashboardPanelsAsync();
    }
}
