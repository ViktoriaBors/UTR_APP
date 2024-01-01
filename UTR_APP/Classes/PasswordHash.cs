using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    internal class PasswordHash
    {
        public static string Password_Hash(string password)
        {
            //SHA256 coding
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] bytes = Encoding.UTF8.GetBytes(password);

                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2")); 
                }

                return sb.ToString();
            }
        }

        public static bool Password_Hash_Decode(string hashedPassword, string password)
        {
            string passwordHex = Password_Hash(password);
            // return passwordHex.Equals(hashedPassword);
            return string.Equals(hashedPassword, passwordHex, StringComparison.OrdinalIgnoreCase);
        }

    }
}
