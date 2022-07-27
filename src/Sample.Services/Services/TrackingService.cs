using CommerceApiSDK.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Sample.Services.Services;

public class TrackingService : ITrackingService
{
    private readonly ILogger _logger;

    public TrackingService(ILogger<TrackingService> logger)
    {
        _logger = logger;
    }
    public ISessionService SessionService { get; }

    public void Initialize() { }

    public void TrackEvent(AnalyticsEvent analyticsEvent) 
    {
        _logger.LogInformation(analyticsEvent.EventName + Environment.NewLine + (analyticsEvent.Properties?.ToString() ?? ""));
    }

    public void TrackException(
        Exception exception,
        Dictionary<string, string> properties = null
    )
    {
        _logger.LogError(exception.Message + Environment.NewLine + (properties?.ToString() ?? ""), exception);
    }

    public void ForceCrash() { }

    public void SetUserID(string userId) 
    {

    }
}
