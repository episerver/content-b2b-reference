namespace Sample.Models.ViewModels;

public class ServiceWidgetBlockItemViewModel
{
    public virtual ContentReference ServiceIcon { get; set; }
    public virtual string Title { get; set; }
    public virtual string Description { get; set; }
    public virtual string ServiceButtonText { get; set; }
    public virtual Url ServiceButtonLink { get; set; }
}