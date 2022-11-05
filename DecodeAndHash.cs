using System.Xml;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

namespace CSVHasherCode
{
    public class DecodeAndHash
    {
        public static string GetHash(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }

        public static void CreateWriteCSV()
        {

        }
    }
}
