using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieDB_Info_Library.ViewModel
{
    class HashPassword
    {
        public static string ComputeHash(string Password, string Salt)
        {
            //https://www.thatsoftwaredude.com/content/6218/how-to-encrypt-passwords-using-sha-256-in-c-and-net

            string sPassword = Password + Salt;
            SHA512 sha512 = SHA512Managed.Create();
            UTF8Encoding objUtf8 = new UTF8Encoding();
            byte[] hashValue = sha512.ComputeHash(objUtf8.GetBytes(sPassword));

            //Convertiert das Passwort in eine Hash der 128 Zeichen lang ist.
            return (BitConverter.ToString(hashValue)).Replace("-","");
        }


        //https://www.geeksforgeeks.org/c-sharp-randomly-generating-strings/
        public static string CreateSalt(int stringlen)
        {
            Random res = new Random();

            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomstring = "";

            for (int i = 0; i < stringlen; i++)
            {
                int x = res.Next(str.Length);
                randomstring = randomstring + str[x];
            }
            return randomstring;
        }
    }
}
