using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WheeMVC.Hash
{
    public class HashFile
    {
        public string Hasher(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA1Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}