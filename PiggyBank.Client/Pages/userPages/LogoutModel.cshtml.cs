using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PiggyBank.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace PiggyBank.Pages;

public class LogoutModel : PageModel
{
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(ILogger<LogoutModel> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await HttpContext.SignOutAsync();
        return RedirectToPage("/Login");
        
    }
}