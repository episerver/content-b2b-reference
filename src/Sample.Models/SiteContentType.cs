namespace Sample.Models;

public class SiteContentType : ContentTypeAttribute
{
    public SiteContentType()
    {
        GroupName = Global.GroupNames.Default;
    }
}
