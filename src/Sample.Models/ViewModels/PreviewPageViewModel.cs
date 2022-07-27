namespace Sample.Models.ViewModels;

public class PreviewPageViewModel : ContentViewModel<BasePage>
{
    public PreviewPageViewModel()
    {

    }

    public PreviewPageViewModel(BasePage currentPage, IContent contentToPreview)
        : base(currentPage)
    {
        PreviewArea = new ContentArea();
        PreviewArea.Items.Add(new ContentAreaItem { ContentLink = contentToPreview.ContentLink });
    }

    public ContentArea PreviewArea { get; set; }
}