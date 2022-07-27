namespace Sample.Models.ViewModels;

public class PromoBarBlockViewModel : IBlockViewModel<PromoBarBlock>
{
    public PromoBarBlockViewModel(PromoBarBlock currentBlock)
    {
        CurrentBlock = currentBlock;
    }

    public PromoBarBlock CurrentBlock { get; }
}