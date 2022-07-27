namespace Sample.Models.ViewModels;

public class MyAccountPageViewModel : ContentViewModel<MyAccountPage>
{
    public MyAccountPageViewModel()
    {

    }

    public MyAccountPageViewModel(MyAccountPage currentPage) : base(currentPage) { }

    public OrderHistoryViewModel OrderHistoryViewModel { get; set; }
    public MyAccountViewModel MyAccountViewModel { get; set; }
}