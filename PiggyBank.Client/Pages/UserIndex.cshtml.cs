using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PiggyBank.Pages;

public class UserIndexModel : PageModel
{
    private readonly ILogger<UserIndexModel> _logger;

    public UserIndexModel(ILogger<UserIndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}