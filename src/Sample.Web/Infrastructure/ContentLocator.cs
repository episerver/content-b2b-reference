﻿using System.Globalization;
using EPiServer.Filters;

namespace Sample.Web.Infrastructure;

public class ContentLocator
{
    private readonly IContentLoader _contentLoader;
    private readonly IContentProviderManager _providerManager;
    private readonly IPageCriteriaQueryService _pageCriteriaQueryService;

    public ContentLocator(
        IContentLoader contentLoader,
        IContentProviderManager providerManager,
        IPageCriteriaQueryService pageCriteriaQueryService
    )
    {
        _contentLoader = contentLoader;
        _providerManager = providerManager;
        _pageCriteriaQueryService = pageCriteriaQueryService;
    }

    public virtual IEnumerable<T> GetAll<T>(ContentReference rootLink) where T : PageData
    {
        foreach (var child in _contentLoader.GetChildren<PageData>(rootLink))
        {
            var childOfRequestedTyped = child as T;
            if (childOfRequestedTyped != null)
            {
                yield return childOfRequestedTyped;
            }
            foreach (var descendant in GetAll<T>(child.ContentLink))
            {
                yield return descendant;
            }
        }
    }

    public IEnumerable<PageData> FindPagesByPageType(
        PageReference pageLink,
        bool recursive,
        int pageTypeId
    )
    {
        if (ContentReference.IsNullOrEmpty(pageLink))
        {
            throw new ArgumentNullException(
                "pageLink",
                "No page link specified, unable to find pages"
            );
        }

        return recursive
            ? FindPagesByPageTypeRecursively(pageLink, pageTypeId)
            : _contentLoader.GetChildren<PageData>(pageLink);
    }

    private IEnumerable<PageData> FindPagesByPageTypeRecursively(
        PageReference pageLink,
        int pageTypeId
    )
    {
        var criteria = new PropertyCriteriaCollection
        {
            new PropertyCriteria
            {
                Name = "PageTypeID",
                Type = PropertyDataType.PageType,
                Condition = CompareCondition.Equal,
                Value = pageTypeId.ToString(CultureInfo.InvariantCulture)
            }
        };

        if (_providerManager.ProviderMap.CustomProvidersExist)
        {
            var contentProvider = _providerManager.ProviderMap.GetProvider(pageLink);

            if (contentProvider.HasCapability(ContentProviderCapabilities.Search))
            {
                criteria.Add(
                    new PropertyCriteria
                    {
                        Name = "EPI:MultipleSearch",
                        Value = contentProvider.ProviderKey
                    }
                );
            }
        }

        return _pageCriteriaQueryService.FindPagesWithCriteria(pageLink, criteria);
    }
}