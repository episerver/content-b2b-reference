namespace Sample.Models.ViewModels;

public interface IBlockViewModel<out T> where T : BlockData
{
    T CurrentBlock { get; }
}