using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly string key = "12345678901234567890123456789012"; // Debe ser de 32 bytes
    private static readonly string iv = "1234567890123456"; // Debe ser de 16 bytes

    public static string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform encryptor = aes.CreateEncryptor();
        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Convert.ToBase64String(encrypted);
    }

    public static string Decrypt(string encryptedText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform decryptor = aes.CreateDecryptor();
        byte[] inputBytes = Convert.FromBase64String(encryptedText);
        byte[] decrypted = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Encoding.UTF8.GetString(decrypted);
    }
}

