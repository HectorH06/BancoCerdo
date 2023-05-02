using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PiggyBank.Pages;

public class EmpIndexModel : PageModel
{
    private readonly ILogger<EmpIndexModel> _logger;

    public EmpIndexModel(ILogger<EmpIndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}