using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using PiggyBank.Models;
using PiggyBank.Client;

namespace PiggyBank.Pages;

public class RegisterModel : PageModel
{
    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(ILogger<RegisterModel> logger)
    {
        _logger = logger;
    }
    [BindProperty]
    public Usuario User{get;set;}
    Account accountOptions=new Account();
    public void OnPost()
    {
        accountOptions.createAccount(User);
        RedirectToPage();
    }

    public void OnGet()
    {

    }
}