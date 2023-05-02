using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PiggyBank.Pages;

public class LoanModel : PageModel
{
    private readonly ILogger<LoanModel> _logger;

    public LoanModel(ILogger<LoanModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}