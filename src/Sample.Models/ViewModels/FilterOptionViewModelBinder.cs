using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Sample.Models.ViewModels;

public class FilterOptionViewModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var model = new FilterOptionViewModel();
        var query = bindingContext.ActionContext.HttpContext.Request.Query["search"];
        var sort = bindingContext.ActionContext.HttpContext.Request.Query["sort"];
        var page = bindingContext.ActionContext.HttpContext.Request.Query["page"];
        var pageSize = bindingContext.ActionContext.HttpContext.Request.Query["pageSize"];
        var facets = bindingContext.ActionContext.HttpContext.Request.Query["facets"];
        var viewMode = bindingContext.ActionContext.HttpContext.Request.Query["viewMode"];

        EnsurePage(model, page);
        EnsurePageSize(model, pageSize);
        EnsureQ(model, query);
        EnsureSort(model, sort);
        EnsureFacets(model, facets);
        EnsureViewMode(model, viewMode);
        bindingContext.Result = ModelBindingResult.Success(model);
        await Task.CompletedTask;
    }

    protected virtual void EnsurePage(FilterOptionViewModel model, string page)
    {
        if (model.Page < 1)
        {
            if (!string.IsNullOrEmpty(page))
            {
                model.Page = int.Parse(page);
            }
            else
            {
                model.Page = 1;
            }
        }
    }

    protected virtual void EnsurePageSize(FilterOptionViewModel model, string pageSize)
    {
        if (!string.IsNullOrEmpty(pageSize))
        {
            model.PageSize = int.Parse(pageSize);
        }
    }

    protected virtual void EnsureQ(FilterOptionViewModel model, string q)
    {
        if (!string.IsNullOrEmpty(q))
        {
            model.Q = q;
        }
    }

    protected virtual void EnsureSort(FilterOptionViewModel model, string sort)
    {
        if (!string.IsNullOrEmpty(sort))
        {
            model.Sort = sort;
        }
    }

    protected virtual void EnsureFacets(FilterOptionViewModel model, string facets)
    {
        if (!string.IsNullOrEmpty(facets))
        {
            model.SelectedFacet = facets;
        }
    }

    protected virtual void EnsureViewMode(FilterOptionViewModel model, string viewMode)
    {
        if (!string.IsNullOrEmpty(viewMode))
        {
            model.ViewMode = viewMode;
        }
    }
}
