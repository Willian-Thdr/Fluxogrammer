using System.Security.Cryptography;
using System.Text;

public class Encrypt
{
    public static string Connect(string txtSimple, string[] txtArray, string secret)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] key = DeriveKey(secret, salt);
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        string txt = null;

        if (txtArray == null)
        {
            txt = txtSimple;
        } 
        else if (txtSimple == null)
        {
            txt = string.Join(Environment.NewLine, txtArray);
        } 
        else if (txt == null)
        {
            throw new Exception("Erro");
        }

        byte[] plainTextBytes = Encoding.UTF8.GetBytes(txt);
        byte[] cipherText = new byte[plainTextBytes.Length];
        byte[] tag = new byte[16];

        using (AesGcm aes = new AesGcm(key, 16))
        {
            aes.Encrypt(
                nonce,
                plainTextBytes,
                cipherText,
                tag
            );
        }

        byte[] result = new byte[16 + 12 + 16 + cipherText.Length];

        Buffer.BlockCopy(salt, 0, result, 0, 16);
        Buffer.BlockCopy(nonce, 0, result, 16, 12);
        Buffer.BlockCopy(tag, 0, result, 16 + 12, 16);
        Buffer.BlockCopy(cipherText, 0, result, 16 + 12 + 16, cipherText.Length);

        return Convert.ToBase64String(result);
    }

    public static string Decrypt(string cipherText, string secret)
    {
        byte[] data = Convert.FromBase64String(cipherText);

        int minimumSize = 16 + 12 + 16;

        if (data.Length < minimumSize)
            throw new CryptographicException("Invalid data.");

            byte[] salt = new byte[16];
            Buffer.BlockCopy(data, 0, salt, 0, 16);

            byte[] nonce = new byte[12];
            Buffer.BlockCopy(
                data,
                16,
                nonce,
                0,
                12
            );

            byte[] tag = new byte[16];
            Buffer.BlockCopy(
                data,
                16 + 12,
                tag,
                0,
                16
            );

            int cipherTextLenght = data.Length - 16 - 12 - 16;

            byte[] ciphertext = new byte[cipherTextLenght];

            Buffer.BlockCopy(
                data,
                16 + 12 + 16,
                ciphertext,
                0,
                cipherTextLenght
            );

            byte[] key = DeriveKey(secret, salt);
            byte[] text = new byte[ciphertext.Length];

            try {
                using (AesGcm aes = new AesGcm(key, 16)){
                    aes.Decrypt(
                        nonce,
                        ciphertext,
                        tag,
                        text
                    );
                }
            } catch (CryptographicException) {
                throw new CryptographicException("It's not possible dencrypt this file.\n" + "The key will be incorrect or corrupted.");
            }

            string textDecrypt = Encoding.UTF8.GetString(text);
            return textDecrypt;
    }

    private static byte[] DeriveKey(string secret, byte[] salt){
        using (Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes
        (
            secret,
            salt,
            600_000,
            HashAlgorithmName.SHA256
        )) {
            return kdf.GetBytes(32);
        }
    }
}