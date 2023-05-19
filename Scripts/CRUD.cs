using System;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Models;

namespace PiggyBank.Account{
    class Functions:MiscFunctions{
        public void CreateAccount(Usuario user){
            var db=new PiggyBank.Models.PiggyDatabase();
            int nuevoID = NewID();
            Cuentum cuenta = new Cuentum()
            {
                NoCuenta = nuevoID,
                Password = newPassword(8),
                TipoCuenta = 1
            };
            InfoCuentum infocuenta = new InfoCuentum
            {
                NoCuenta=nuevoID,
                Estado=1
            };
            user.NoCuenta=nuevoID;
            db.Cuentas.Add(cuenta);
            db.InfoCuentas.Add(infocuenta);
            db.Usuarios.Add(user);
            db.SaveChanges();
        }
    }
}