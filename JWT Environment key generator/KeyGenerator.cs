using System.Security.Cryptography;

public class KeyGenerator
{
    public static string GenerateKey()
    {
        byte[] keyBytes = new byte[32];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(keyBytes);
        }

        return Convert.ToBase64String(keyBytes);
    }
}