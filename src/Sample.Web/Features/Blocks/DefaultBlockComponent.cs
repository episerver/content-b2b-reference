namespace Sample.Web.Features.Blocks;

[TemplateDescriptor(Inherited = true)]
public class DefaultBlockComponent : AsyncBlockComponent<BlockData>
{
    protected override async Task<IViewComponentResult> InvokeComponentAsync(BlockData currentBlock)
    {
        var blockName = currentBlock.GetOriginalType().Name;
        if (currentBlock is MenuItemBlock)
        {
            return await Task.FromResult(View(string.Format("~/Features/Blocks/{0}.cshtml", blockName), currentBlock));
        }
        else
        {
            return await Task.FromResult(View(string.Format("~/Features/Blocks/{0}.cshtml", blockName), CreateModel(currentBlock)));
        }
    }

    private static IBlockViewModel<BlockData> CreateModel(BlockData currentBlock)
    {
        var type = typeof(BlockViewModel<>).MakeGenericType(currentBlock.GetOriginalType());
        return Activator.CreateInstance(type, currentBlock) as IBlockViewModel<BlockData>;
    }
}