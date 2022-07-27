namespace Sample.Web.Infrastructure;

public class SampleContentAreaRenderer : ContentAreaRenderer
{
    protected override string GetContentAreaItemCssClass(IHtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
    {
        var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
        return $"{tag ?? "basis-full"}";
    }
}
