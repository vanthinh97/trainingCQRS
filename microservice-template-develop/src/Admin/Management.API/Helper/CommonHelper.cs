﻿using System.Security.Cryptography;
using System.Text;

namespace Management.API.Helper
{
    public class CommonHelper : ICommonHelper
    {
        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public string HashSha256(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
