namespace Sample.Services.Category;

public interface ICategoryService
{
    Task<List<CommerceApiSDK.Models.Category>> GetCategoryList(
        string startCategoryId,
        string maxDepth
    );
    Task<List<CommerceApiSDK.Models.Category>> GetCategoryList();
    Task<CommerceApiSDK.Models.Category> GetCategoryById(string categoryId);
}
