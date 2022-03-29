using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoIntegradorUlifeParaDevs.Helpers
{
    public static class CryptoHelper
    {
        public static string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-","");
        }
    }
}