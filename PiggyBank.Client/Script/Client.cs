using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using PiggyBank.Models;
using PiggyBank.Pages;


namespace PiggyBank.Client
{
    class Account:Generate
    {
        public  void createAccount(Usuario user){
            var db=new PiggyBank.Models.PiggyDatabase();
            int newID=NewID();
            Cuentum cuenta=new Cuentum
            {
                NoCuenta=newID,
                Password=newPassword(8),
                TipoCuenta=1,
            };
            InfoCuentum infocuenta=new InfoCuentum
            {
                NoCuenta=newID,
                Estado=1
            };
            user.NoCuenta=newID;
            db.Cuentas.Add(cuenta);
            db.InfoCuentas.Add(infocuenta);
            db.Usuarios.Add(user);
            db.SaveChanges();
        }

        public void LogIn(Credential credentials)
        {

        }
    }
}