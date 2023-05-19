using System.Security.Cryptography;
namespace PiggyBank.Account
{
    class MiscFunctions{
        protected static int NewID()
        {
            var db=new PiggyBank.Models.PiggyDatabase();
            Random random=new Random();
            int NoCuenta;
            IQueryable<long> exist;
            do{
            NoCuenta=random.Next(1000000,9999999);
            exist=from s in db.Cuentas where s.NoCuenta==NoCuenta select s.NoCuenta;
            }while(exist.Count()>0);
            return NoCuenta;
        }
        protected static string newPassword(int length)
        {
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }
    }
}