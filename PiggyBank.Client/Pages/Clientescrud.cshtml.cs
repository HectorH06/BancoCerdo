using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PiggyBank.Pages;

public class ClientescrudModel : PageModel
{
    private readonly ILogger<RegisterModel> _logger;

    public ClientescrudModel(ILogger<RegisterModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}