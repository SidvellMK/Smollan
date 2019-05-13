using System;
using System.Security.Cryptography;
using System.Text;

namespace FinanceReportingRegistrationAPI.Helpers
{
    public sealed class SaltedHash
    {
        private readonly string _hash;
        private const int saltLength = 12;

        public string Hash
        {
            get
            {
                return _hash;
            }
        }

        public string Salt { get; }

        private SaltedHash(string s, string h)
        {
            _hash = h;
            Salt = s;
        }

        public static SaltedHash Create(string password)
        {
            string salt = CreateSalt();
            string hash = CalculateHash(salt, password);

            return new SaltedHash(salt, hash);
        }

        public static SaltedHash Create(string salt, string hash)
        {
            return new SaltedHash(salt, hash);
        }

        public bool Verify(string password)
        {
            string hash = CalculateHash(Salt, password);
            return _hash.Equals(hash);
        }

        private static string CreateSalt()
        {
            byte[] r = CreateRandomSalt(saltLength);
            return Convert.ToBase64String(r);
        }

        private static byte[] CreateRandomSalt(int saltLen)
        {
            byte[] r = new byte[saltLen];
            new RNGCryptoServiceProvider().GetBytes(r);

            return r;
        }

        private static string CalculateHash(string salt, string password)
        {
            byte[] data = ToByteArray(salt + password);
            byte[] hash = CalculateHash(data);

            return Convert.ToBase64String(hash);
        }

        private static byte[] ToByteArray(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        private static byte[] CalculateHash(byte[] data)
        {
            return new SHA1CryptoServiceProvider().ComputeHash(data);
        }
    }
}
