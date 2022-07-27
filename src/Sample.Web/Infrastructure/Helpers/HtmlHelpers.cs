using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace Sample.Web.Infrastructure.Helpers;

public static class HtmlHelpers
{
    private static Lazy<ISettingsHelper> _settingsHelper = new Lazy<ISettingsHelper>(() => ServiceLocator.Current.GetInstance<ISettingsHelper>());
    private static Lazy<IUrlResolver> _urlResolver = new Lazy<IUrlResolver>(() => ServiceLocator.Current.GetInstance<IUrlResolver>());
    private static Lazy<IContentLanguageAccessor> _contentLanguageAccessor = new Lazy<IContentLanguageAccessor>(() => ServiceLocator.Current.GetInstance<IContentLanguageAccessor>());
    private static readonly Lazy<IContextModeResolver> _contextModeResolver =
           new Lazy<IContextModeResolver>(() => ServiceLocator.Current.GetInstance<IContextModeResolver>());

    public static string GetPageReferenceUrl<TSettings>(this IHtmlHelper htmlHelper, Func<TSettings, ContentReference> getReference) where TSettings : SettingsBase
    {
        var setting = _settingsHelper.Value.GetSettings<TSettings>();
        if (setting == null)
        {
            return null;
        }

        var reference = getReference(setting);
        if (ContentReference.IsNullOrEmpty(reference))
        {
            return null;
        }

        return _urlResolver.Value.GetUrl(reference, _contentLanguageAccessor.Value.Language?.Name ?? "en");
    }
    public static HtmlString SampleValidationMessageFor<TModel, TProperty>(
        this IHtmlHelper<TModel> helper,
        Expression<Func<TModel, TProperty>> expression
    )
    {
        var field = helper.GetExpressionText(expression);
        var modelName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(field);
        if (!helper.ViewData.ModelState.ContainsKey(modelName))
        {
            return null;
        }
        var modelState = helper.ViewData.ModelState[modelName];
        var modelErrors = modelState == null ? null : modelState.Errors;
        var modelError =
            modelErrors == null || modelErrors.Count == 0
                ? null
                : modelErrors.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage))
                  ?? modelErrors[0];
        if (modelError == null)
        {
            return null;
        }

        var containerDivBuilder = new TagBuilder("div");
        containerDivBuilder.AddCssClass("error error-inline");

        var topDivBuilder = new TagBuilder("span");
        topDivBuilder.AddCssClass("icon-exclamation-solid");
        var writer = new StringWriter();
        topDivBuilder.TagRenderMode = TagRenderMode.Normal;
        topDivBuilder.WriteTo(writer, HtmlEncoder.Default);
        containerDivBuilder.InnerHtml.Append(
            InnerHtml(
                writer.ToString(),
                GetUserErrorMessageOrDefault(modelError,
                    modelState
                )
            )
        );
        containerDivBuilder.TagRenderMode = TagRenderMode.Normal;
        containerDivBuilder.WriteTo(writer, HtmlEncoder.Default);
        return new HtmlString(writer.ToString());
    }

    public static string GetString(this IHtmlContent content)
    {
        var writer = new StringWriter();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }

    public static string GetExpressionText<TModel, TResult>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TResult>> expression
    )
    {
        var expressionProvider =
            htmlHelper.ViewContext.HttpContext.RequestServices.GetService(
                typeof(ModelExpressionProvider)
            ) as ModelExpressionProvider;

        return expressionProvider.GetExpressionText(expression);
    }

    public static HtmlString ValidationSummary(this IHtmlHelper helper)
    {
        if (helper.ViewData.ModelState.IsValid)
            return HtmlString.Empty;

        var containerDivBuilder = new TagBuilder("div");
        containerDivBuilder.AddCssClass("validation-summary-error-side");

        var topDivBuilder = new TagBuilder("span");
        topDivBuilder.AddCssClass("icon-exclamation-solid");
        foreach (var key in helper.ViewData.ModelState.Keys)
        {
            foreach (var err in helper.ViewData.ModelState[key].Errors)
            {
                var containerDivRowBuilder = new TagBuilder("div");
                containerDivRowBuilder.AddCssClass("row error-row");
                var writer = new StringWriter();
                topDivBuilder.TagRenderMode = TagRenderMode.Normal;
                topDivBuilder.WriteTo(writer, HtmlEncoder.Default);
                containerDivRowBuilder.InnerHtml.Append(
                    InnerHtml(writer.ToString(), helper.Encode(err.ErrorMessage))
                );
                containerDivBuilder.InnerHtml.AppendHtml(containerDivRowBuilder.InnerHtml);
                containerDivBuilder.InnerHtml.Append("<br/>");
                containerDivBuilder.TagRenderMode = TagRenderMode.Normal;
            }
        }
        var _writer = new StringWriter();
        containerDivBuilder.WriteTo(_writer, HtmlEncoder.Default);
        return new HtmlString(_writer.ToString());
    }

    public static ConditionalLink BeginConditionalLink(
        this IHtmlHelper helper,
        bool shouldWriteLink,
        IHtmlContent url,
        string title = null,
        string cssClass = null
    )
    {
        if (shouldWriteLink)
        {
            var linkTag = new TagBuilder("a");
            linkTag.Attributes.Add("href", url.ToString());

            if (!string.IsNullOrWhiteSpace(title))
            {
                linkTag.Attributes.Add("title", helper.Encode(title));
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                linkTag.Attributes.Add("class", cssClass);
            }
            var writer = new StringWriter();
            linkTag.RenderStartTag().WriteTo(helper.ViewContext.Writer, HtmlEncoder.Default);
        }
        return new ConditionalLink(helper.ViewContext, shouldWriteLink);
    }

    public static ConditionalLink BeginConditionalLink(
        this IHtmlHelper helper,
        bool shouldWriteLink,
        Func<HtmlString> urlGetter,
        string title = null,
        string cssClass = null
    )
    {
        var url = HtmlString.Empty;

        if (shouldWriteLink)
        {
            url = urlGetter();
        }

        return helper.BeginConditionalLink(shouldWriteLink, url, title, cssClass);
    }

    public static bool IsInEditMode(this IHtmlHelper htmlHelper) => _contextModeResolver.Value.CurrentMode == ContextMode.Edit;

    private static string InnerHtml(string errorIcon, string errorMessage)
    {
        return errorIcon + "<span class='err-message'>" + errorMessage + "</span>";
    }

    private static string GetUserErrorMessageOrDefault(ModelError error,
        ModelStateEntry modelState
    )
    {
        if (!string.IsNullOrEmpty(error.ErrorMessage))
        {
            return error.ErrorMessage;
        }
        if (modelState == null)
        {
            return null;
        }
        return modelState.AttemptedValue;
    }
}

public class ConditionalLink : IDisposable
{
    private readonly ViewContext _viewContext;
    private readonly bool _linked;
    private bool _disposed;

    public ConditionalLink(ViewContext viewContext, bool isLinked)
    {
        _viewContext = viewContext;
        _linked = isLinked;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        if (_linked)
        {
            _viewContext.Writer.Write("</a>");
        }
    }
}
