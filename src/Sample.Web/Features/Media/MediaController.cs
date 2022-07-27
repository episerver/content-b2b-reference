using EPiServer.Framework.Web;
using Sample.Models.Media;

namespace Sample.Web.Features.Media;

[TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialComponent, Inherited = true)]
public class MediaController : AsyncPartialContentComponent<MediaData>
{
    private readonly UrlResolver _urlResolver;
    private readonly IContextModeResolver _contextModeResolver;

    public MediaController(UrlResolver urlResolver, IContextModeResolver contextModeResolver)
    {
        _urlResolver = urlResolver;
        _contextModeResolver = contextModeResolver;
    }

    protected override async Task<IViewComponentResult> InvokeComponentAsync(MediaData currentContent)
    {
        switch (currentContent)
        {
            case VideoFile videoFile:
                var videoViewModel = new VideoFileViewModel
                {
                    DisplayControls = videoFile.DisplayControls,
                    Autoplay = videoFile.Autoplay,
                    Copyright = videoFile.Copyright
                };

                if (_contextModeResolver.CurrentMode == ContextMode.Edit)
                {
                    videoViewModel.VideoLink = _urlResolver.GetUrl(videoFile.ContentLink, null, new VirtualPathArguments { ContextMode = ContextMode.Default });
                    videoViewModel.PreviewImage = ContentReference.IsNullOrEmpty(videoFile.PreviewImage) ? string.Empty :
                       _urlResolver.GetUrl(videoFile.PreviewImage, null, new VirtualPathArguments { ContextMode = ContextMode.Default });
                }
                else
                {
                    videoViewModel.VideoLink = _urlResolver.GetUrl(videoFile.ContentLink);
                    videoViewModel.PreviewImage = ContentReference.IsNullOrEmpty(videoFile.PreviewImage) ? string.Empty : _urlResolver.GetUrl(videoFile.PreviewImage);
                }
                return await Task.FromResult(View("~/Features/Media/VideoFile.cshtml", videoViewModel));
            case ImageMediaData image:
                var imageViewModel = new ImageMediaDataViewModel
                {
                    Name = image.Name,
                    Description = image.Description,
                };

                if (_contextModeResolver.CurrentMode == ContextMode.Edit)
                {
                    imageViewModel.ImageLink = _urlResolver.GetUrl(image.ContentLink, null, new VirtualPathArguments { ContextMode = ContextMode.Default });
                    imageViewModel.LinkToContent = ContentReference.IsNullOrEmpty(image.Link) ? string.Empty :
                       _urlResolver.GetUrl(image.Link, null, new VirtualPathArguments { ContextMode = ContextMode.Default });
                }
                else
                {
                    imageViewModel.ImageLink = _urlResolver.GetUrl(image.ContentLink);
                    imageViewModel.LinkToContent = ContentReference.IsNullOrEmpty(image.Link) ? string.Empty : _urlResolver.GetUrl(image.Link);
                }

                return await Task.FromResult(View("~/Features/Media/ImageMedia.cshtml", imageViewModel));
            default:
                return await Task.FromResult(View("~/Features/Media/Index.cshtml", currentContent.GetType().BaseType.Name));
        }
    }
}