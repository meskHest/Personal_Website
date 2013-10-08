using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PersonalSite.Helpers
{
    public class SecurityHelper
    {
        public static string CreateSalt()
        {
            var size = new Random().Next(140, 200);
            var cryptoService = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            cryptoService.GetBytes(buff);

            return Convert.ToBase64String(buff).Substring(0, size);
        }

        public static string GenerateHash(string str, string salt)
        {
            const string methodSalt = "6seMtQ1U1w+8RnQdPd541BrL/6cveb0KOfn6LadtocbZ6cdpXcyxpQy1+cyJ3OETi467i+pWwfwYXwWh3zdR+EXGgTnLQPREksoKQVjkMr8ZOPY1d5eCvySQpBqQm3m7WHowyjfNjFafot8G/lJ4bxJHbMHrvsL8FvdO41kOxMmJL+0iHoOmRmaCo";
            var bytes = Encoding.Unicode.GetBytes(string.Concat(methodSalt, str, salt));
            var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}