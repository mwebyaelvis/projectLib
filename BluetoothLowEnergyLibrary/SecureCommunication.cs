using System.Security.Cryptography;
using System.Text;

namespace BluetoothLowEnergyLibrary;

public class SecureCommunication
{
    public string EncryptData(string plainText, string key)
    {
        using var aesAlg = Aes.Create();
        var encryptor = aesAlg.CreateEncryptor(Encoding.UTF8.GetBytes(key), aesAlg.IV);
        var encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);
        return Convert.ToBase64String(aesAlg.IV) + ":" + Convert.ToBase64String(encrypted);
    }

    public string DecryptData(string cipherText, string key)
    {
        var parts = cipherText.Split(':');
        var iv = Convert.FromBase64String(parts[0]);
        var encrypted = Convert.FromBase64String(parts[1]);

        using var aesAlg = Aes.Create();
        var decryptor = aesAlg.CreateDecryptor(Encoding.UTF8.GetBytes(key), iv);
        var decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
        return Encoding.UTF8.GetString(decrypted);
    }
}