using System.Security.Cryptography;

namespace PiggyBank.Client
{
    public class Generate
    {
        protected string newPassword(int length)
        {
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }
        protected int NewID()
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
        protected int NewFolio()
        {
            var db=new PiggyBank.Models.PiggyDatabase();
            Random random=new Random();
            int folio;
            IQueryable<long> exist;
            do{
            folio=random.Next(100000000,999999999);
            exist=from s in db.Prestamos where s.Folio==folio select s.Folio;
            }while(exist.Count()>0);
            return folio;
        }
    }
}