using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PiggyBank.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace PiggyBank.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(ILogger<LoginModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public Credential credential {get;set;}
    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid)
            return Page();

        var db=new PiggyBank.Models.PiggyDatabase();
        Cuentum? user=db.Cuentas
            .Where(c=>c.NoCuenta.Equals(credential.noCuenta)).FirstOrDefault();
       
        if(user==null)
            return Page();

        if(user.Password==credential.password)
        {
            var claims=new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.NoCuenta.ToString()),
                new Claim(ClaimTypes.AuthorizationDecision,db.InfoCuentas
                    .Where(i=>i.NoCuenta.Equals(user.NoCuenta))
                    .Select(i=>i.Estado).Single().ToString())
            };
            var identity=new ClaimsIdentity(claims,"PiggyCookie");
            ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("PiggyCookie",claimsPrincipal);
            return RedirectToPage("/userPages/UserIndex");
        }
        
        return Page();
    }
    public void OnGet()
    {

    }
}

    public class Credential
    {
        [Required]
        public long noCuenta{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }