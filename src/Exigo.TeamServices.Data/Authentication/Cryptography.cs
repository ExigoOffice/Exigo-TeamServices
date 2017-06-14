using System;
using System.Security;
using System.Security.Cryptography;

using Exigo.TeamServices.Data.Core.Extensions;

namespace Exigo.TeamServices.Data.Authentication
{
    public class Cryptography
    {
        private const int SALT_BYTE_SIZE = 32;
        private const int HASH_BYTE_SIZE = 32;
        private const int PBKDF2_ITERATIONS = 1000;

        private const int ITERATION_INDEX = 0;
        private const int SALT_INDEX = 1;
        private const int PBKDF2_INDEX = 2;

        /// <summary>
        ///     Create hash from salted password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CreateHash(string password)
        {
            var salt = new byte[SALT_BYTE_SIZE];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var hash = Pbkdf2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

            return $"{PBKDF2_ITERATIONS}:{salt.ToBase64String()}:{hash.ToBase64String()}";
        }

        /// <summary>
        ///     Validation entry method
        /// </summary>
        /// <param name="password"></param>
        /// <param name="correctHash"></param>
        /// <returns></returns>
        public static bool ValidatePassword(SecureString password, string correctHash)
        {
            char[] delimiter = {':'};
            var split = correctHash.Split(delimiter);
            var iterations = int.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            return SlowEquals(hash, Pbkdf2(password.ConvertToUnsecureString(), salt, iterations, hash.Length));
        }

        /// <summary>
        ///     Hash validation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint) a.Length ^ (uint) b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint) (a[i] ^ b[i]);

            return diff == 0;
        }

        /// <summary>
        ///     Generate the PBKDF2-SHA1 hash of a password.
        /// </summary>
        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt) {IterationCount = iterations})
                return pbkdf2.GetBytes(outputBytes);
        }
    }
}