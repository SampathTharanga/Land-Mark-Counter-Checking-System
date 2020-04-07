using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataAccessLayer; //DATA ACCESS LAYER
using System.Text.RegularExpressions;

namespace BusinessLogicLayer
{
    public class UserClassBLL
    {
        //USER PROPERTIES
        public string username { get; set; }
        public string userType { get; set; }
        public string password { get; set; }
        public string secQue { get; set; }
        public string secAns { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string division { get; set; }




        //USER BUSINESS LAYER CLASS OBJECT
        public UserClassDAL objUserClsBL = new UserClassDAL();

        //ENCRYPT AND DECRYPT KEY
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        //ADD NEW USER
        public void AddNewUser(UserModel model)
        {
            objUserClsBL.AddNewUserDB(model);
        }
        //PASSWORD ENCRYPT
        private string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        //PASSWORD DECRYPT
        private string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        //LOAD DATA
        public object LoadUserData()
        {
            return objUserClsBL.LoadUserData();
        }

    }
}
