namespace Sample.Models.ViewModels;

public class ContentViewModel<T> : IContentViewModel<T> where T : BasePage
{
    private Injected<IContentLoader> _contentLoader;
    private Injected<IContentLanguageAccessor> _languageAccessor;
    private HomePage _startPage;

    public ContentViewModel() : this(default)
    {

    }
    public ContentViewModel(T currentPage)
    {
        CurrentContent = currentPage;
        Language = _languageAccessor.Service.Language?.Name;
    }

    public string Language { get; }
    public T CurrentContent { get; set; }

    public virtual HomePage StartPage
    {
        get
        {
            if (_startPage == null && !ContentReference.IsNullOrEmpty(ContentReference.StartPage))
            {
                _startPage = _contentLoader.Service.Get<HomePage>(ContentReference.StartPage);
            }

            if (_startPage == null)
            {
                return null;
            }
            return _startPage;
        }
    }
}

public static class ContentViewModel
{
    /// <summary>
    /// Returns a PageViewModel of type <typeparam name="T"/>.
    /// </summary>
    /// <remarks>
    /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
    /// </remarks>
    public static ContentViewModel<T> Create<T>(T page) where T : BasePage
    {
        return new ContentViewModel<T>(page);
    }
}