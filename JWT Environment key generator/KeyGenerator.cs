using System.Security.Cryptography;
using System.Text;

public class KeyGenerator
{
    public static string GenerateKey()
    {
        // Generate a random key
        byte[] keyBytes = new byte[20]; // Since base32 encoding requires 160 bits (20 bytes) to represent 32 characters
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(keyBytes);
        }

        // Encode the key as a base32 string
        string base32Key = Base32Encode(keyBytes);

        // Get the first 32 characters of the base32 string
        return base32Key.Substring(0, 32);
    }

    // Base32 encoding implementation
    private static string Base32Encode(byte[] data)
    {
        const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        StringBuilder sb = new StringBuilder();
        int byteSize = 8;
        int buffer = data[0];
        int next = 1;
        int bitsLeft = byteSize;
        while (bitsLeft > 0 || next < data.Length)
        {
            if (bitsLeft < 5)
            {
                if (next < data.Length)
                {
                    buffer <<= byteSize;
                    buffer |= data[next++];
                    bitsLeft += byteSize;
                }
                else
                {
                    int pad = 5 - bitsLeft;
                    buffer <<= pad;
                    bitsLeft += pad;
                }
            }

            int index = 31 & (buffer >> (bitsLeft - 5));
            bitsLeft -= 5;
            sb.Append(base32Chars[index]);
        }

        return sb.ToString();
    }
}
