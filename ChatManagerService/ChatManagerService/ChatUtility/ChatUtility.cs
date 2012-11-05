using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChatManagerService.ChatUtility
{
    public static class ChatUtility
    {
        public static string EncryptPassword(string password, string salt)
        {
            string encryptedPassword = string.Empty;
            byte[] bytePasswordRepresentation = UnicodeEncoding.UTF8.GetBytes(string.Concat(password, salt));
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] hashedTextinBytes = null;
                hashedTextinBytes = md5.ComputeHash(bytePasswordRepresentation);
                encryptedPassword = Convert.ToBase64String(hashedTextinBytes);
            }
            return encryptedPassword;
        }
    }
}