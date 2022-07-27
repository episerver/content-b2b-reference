namespace Sample.Models.ViewModels;

public class InvoiceDetailsViewModel
{
    public string InvoiceDetailPageUrl { get; set; }
    public bool AllowToSearch { get; set; }
    public bool ShowTopNavigation { get; set; }
    public bool ShowBottomNavigation { get; set; }
    public PaginationExtendedModel Pagination { get; set; }
    public Invoice Invoice { get; set; }
}