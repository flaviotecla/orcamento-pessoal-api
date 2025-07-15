using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace orcamento_pessoal_api.Helpers
{
    public class SenhaHelper
    {
        public static string GenerateSalt()
        {
            var bytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static string GenerateHash(string senha, string salt)
        {
            using var sha256 = SHA256.Create();
            var senhaComSalt = Encoding.UTF8.GetBytes(senha + salt);
            var hash = sha256.ComputeHash(senhaComSalt);
            return Convert.ToBase64String(hash);
        }
    }
}