namespace Sample.Services.Category;

public class CategoryService : BaseService, ICategoryService
{
    private CommerceApiSDK.Services.Interfaces.ICategoryService _categoryClient;

    public CategoryService(CommerceApiSDK.Services.Interfaces.ICategoryService categoryClient)
    {
        _categoryClient = categoryClient;
    }

    public virtual async Task<List<CommerceApiSDK.Models.Category>> GetCategoryList(
        string startCategoryId,
        string maxDepth
    )
    {
        return await _categoryClient.GetCategoryList(
            new CategoryQueryParameters
            {
                StartCategoryId = string.IsNullOrEmpty(startCategoryId)
                  ? null
                  : Guid.Parse(startCategoryId),
                MaxDepth = int.Parse(maxDepth)
            }
        );
    }

    public virtual async Task<List<CommerceApiSDK.Models.Category>> GetCategoryList()
    {
        return await _categoryClient.GetFeaturedCategories(new CategoryQueryParameters());
    }

    public virtual async Task<CommerceApiSDK.Models.Category> GetCategoryById(string categoryId)
    {
        return await _categoryClient.GetCategory(Guid.Parse((ReadOnlySpan<char>)categoryId));
    }
}
