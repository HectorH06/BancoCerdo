using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PiggyBank.Pages;

public class LoanHistoryModel : PageModel
{
    private readonly ILogger<LoanHistoryModel> _logger;

    public LoanHistoryModel(ILogger<LoanHistoryModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}