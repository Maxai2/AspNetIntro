using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Authetification.Extensions
{
    public static class StringExtensions
    {
        public static string Sha256(this string pswd, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.Default.GetBytes(pswd + salt);

                bytes = sha.ComputeHash(bytes);

                return Encoding.Default.GetString(bytes);
            }
        }

        public static (string pswdhash, string salt) Encrypt(this string pswd)
        {
            byte[] bytes = new byte[32];
            new Random().NextBytes(bytes);
            string salt = Encoding.Default.GetString(bytes);
            string hash = Sha256(pswd, salt);

            return (hash, salt);
        }
    }
}
