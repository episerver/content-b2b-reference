namespace Sample.Models.ViewModels;

/// <summary>
/// Defines common characteristics for view models for pages, including properties used by layout files.
/// </summary>
/// <remarks>
/// Views which should handle several page types (T) can use this interface as model type rather than the
/// concrete PageViewModel class, utilizing the that this interface is covariant.
/// </remarks>
public interface IContentViewModel<out T> where T : IContent
{
    T CurrentContent { get; }
    HomePage StartPage { get; }
}