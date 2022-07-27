using Microsoft.Extensions.Logging;

namespace Sample.Web.Features.MyAccount;

public class CreateAccountPageController : PageControllerBase<CreateAccountPage>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAccountService _accountService;
    private readonly LocalizationService _localizationService;
    private readonly ILogger _logger;

    public CreateAccountPageController(IAuthenticationService authenticationService,
        IAccountService accountService,
        LocalizationService localizationService,
        ILogger<CreateAccountPageController> logger)
    {
        _authenticationService = authenticationService;
        _accountService = accountService;
        _localizationService = localizationService;
        _logger = logger;
    }

    public async Task<IActionResult> Index(CreateAccountPage currentPage)
    {
        var isAuthenticated = await _authenticationService.IsAuthenticatedAsync();
        var model = new CreateAccountPageViewModel(currentPage);
        var HomePageUrl = "/";
        if (!isAuthenticated)
        {
            model.CreateAccountViewModel = new CreateAccountViewModel();
            model.ErrorMessage = new List<string>();
        }
        else
        {
            return Redirect(HomePageUrl);
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Index(CreateAccountPage currentPage, CreateAccountPageViewModel createAccountPageViewModel)
    {
        createAccountPageViewModel.CurrentContent = currentPage;
        createAccountPageViewModel.ErrorMessage = new List<string>();
        var HomePageUrl = "/";
        if (!ModelState.IsValid)
        {
            createAccountPageViewModel.ErrorMessage = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
            return View(createAccountPageViewModel);
        }

        try
        {
            var result = await _accountService.CreateAccount(createAccountPageViewModel.CreateAccountViewModel.Email,
                createAccountPageViewModel.CreateAccountViewModel.Username,
                createAccountPageViewModel.CreateAccountViewModel.Password,
                (createAccountPageViewModel.CreateAccountViewModel.IsSubscribed ?? "").Equals("on"));

            if (result == null)
            {
                var localizedFailureMessage = _localizationService.GetString("/CreateAccount/Form/Error/CreateAccountFailure");
                _logger.LogError($"{localizedFailureMessage} Error: Could not create account");
                createAccountPageViewModel.ErrorMessage = new List<string>() { localizedFailureMessage };
            }

            var resFromSignIn = await _authenticationService.SignInAsync(
                createAccountPageViewModel.CreateAccountViewModel.Username,
                createAccountPageViewModel.CreateAccountViewModel.Password
            );
            if (resFromSignIn.Item1)
            {
                return Redirect(HomePageUrl);
            }

        }
        catch (Exception ex)
        {
            createAccountPageViewModel.ErrorMessage = new List<string>() { ex.Message };
        }
        return View(createAccountPageViewModel);
    }
}
