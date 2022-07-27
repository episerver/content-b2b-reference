namespace Sample.Models;

public class SiteImageUrl : ImageUrlAttribute
{
    public SiteImageUrl() : this("~/icons/optimizely_logo_navigation.svg") { }

    public SiteImageUrl(string path) : base(path) { }
}
