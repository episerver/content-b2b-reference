namespace Sample.Models.ViewModels;

public class RecentOrderBlockViewModel
{
    public OrderHistoryViewModel OrderHistoryViewModel { get; set; }
    public RecentOrdersBlock RecentOrdersBlock { get; set; }
    public string ViewAllLink { get; set; }
}