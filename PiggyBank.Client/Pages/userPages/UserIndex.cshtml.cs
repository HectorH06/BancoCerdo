using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PiggyBank.Pages;
public class UserIndexModel : PageModel
{
    private readonly ILogger<UserIndexModel> _logger;

    public UserIndexModel(ILogger<UserIndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        var db=new PiggyBank.Models.PiggyDatabase();
        if(HttpContext.User.FindFirst(ClaimTypes.AuthorizationDecision).Value!="1")
            return RedirectToPage("/Login");
        return Page();
    }
}