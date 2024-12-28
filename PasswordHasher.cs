using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class Password
    {
        // Hash a password using PBKDF2
        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Generate the hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000); // 10,000 iterations
            byte[] hash = pbkdf2.GetBytes(32); // Generate a 256-bit (32-byte) hash

            // Combine the salt and hash
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16); // First 16 bytes are the salt
            Array.Copy(hash, 0, hashBytes, 16, 32); // Next 32 bytes are the hash

            // Convert to Base64 for storage
            return Convert.ToBase64String(hashBytes);
        }

        // Verify a password against a stored hash
        public static bool VerifyPassword(string password, string storedHash)
        {
            // Decode the stored hash
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract the salt from the hash
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Hash the input password using the same salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(32);

            // Compare the hash of the input password with the stored hash
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false; // Passwords do not match
            }

            return true; // Passwords match
        }

       
    }

}
