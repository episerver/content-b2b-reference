namespace Sample.Web.Features.Blocks;

[TemplateDescriptor(Inherited = true)]
public class DefaultBlockComponent : AsyncBlockComponent<BlockData>
{
    protected override async Task<IViewComponentResult> InvokeComponentAsync(BlockData currentBlock)
    {
        var model = CreateModel(currentBlock);
        var blockName = currentBlock.GetOriginalType().Name;
        return await Task.FromResult(View(string.Format("~/Features/Blocks/{0}.cshtml", blockName), model));
    }

    private static IBlockViewModel<BlockData> CreateModel(BlockData currentBlock)
    {
        var type = typeof(BlockViewModel<>).MakeGenericType(currentBlock.GetOriginalType());
        return Activator.CreateInstance(type, currentBlock) as IBlockViewModel<BlockData>;
    }
}