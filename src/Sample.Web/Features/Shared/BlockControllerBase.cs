namespace Sample.Web.Features.Shared;

public abstract class BlockControllerBase<TBlockData> : AsyncBlockComponent<TBlockData>
    where TBlockData : BlockData
{
    protected override async Task<IViewComponentResult> InvokeComponentAsync(TBlockData currentContent)
    {
        return await Index(currentContent);
    }

    public IViewComponentResult MyView<TModel>(TModel model)
    {
        var viewName = string.Format(
            "~/Views/{0}/Index.cshtml",
            ViewComponentContext.ViewComponentDescriptor.ShortName
        );
        return View(viewName, model);
    }

    public abstract Task<IViewComponentResult> Index(TBlockData currentBlock);
}
