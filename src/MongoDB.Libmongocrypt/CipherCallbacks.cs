using System;
using System.Security.Cryptography;

namespace MongoDB.Libmongocrypt
{
    internal static class CipherCallbacks
    {
        public static bool Encrypt(
          IntPtr ctx,
          IntPtr key,
          IntPtr iv,
          IntPtr @in,
          IntPtr @out,
          ref uint bytes_written,
          IntPtr statusPtr)
        {
            using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
            {
                try
                {
                    Binary binary1 = new Binary(BinarySafeHandle.FromIntPtr(key));
                    Binary binary2 = new Binary(BinarySafeHandle.FromIntPtr(@in));
                    Binary binary3 = new Binary(BinarySafeHandle.FromIntPtr(@out));
                    Binary binary4 = new Binary(BinarySafeHandle.FromIntPtr(iv));
                    byte[] bytes = CipherCallbacks.AesCrypt(binary1.ToArray(), binary4.ToArray(), binary2.ToArray(), CryptMode.Encrypt);
                    bytes_written = (uint)bytes.Length;
                    binary3.WriteBytes(bytes);
                    return true;
                }
                catch (Exception ex)
                {
                    status.SetStatus(1U, ex.Message);
                    return false;
                }
            }
        }

        public static bool Decrypt(
          IntPtr ctx,
          IntPtr key,
          IntPtr iv,
          IntPtr @in,
          IntPtr @out,
          ref uint bytes_written,
          IntPtr statusPtr)
        {
            using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
            {
                try
                {
                    Binary binary1 = new Binary(BinarySafeHandle.FromIntPtr(key));
                    Binary binary2 = new Binary(BinarySafeHandle.FromIntPtr(@in));
                    Binary binary3 = new Binary(BinarySafeHandle.FromIntPtr(@out));
                    Binary binary4 = new Binary(BinarySafeHandle.FromIntPtr(iv));
                    byte[] bytes = CipherCallbacks.AesCrypt(binary1.ToArray(), binary4.ToArray(), binary2.ToArray(), CryptMode.Decrypt);
                    bytes_written = (uint)bytes.Length;
                    binary3.WriteBytes(bytes);
                    return true;
                }
                catch (Exception ex)
                {
                    status.SetStatus(1U, ex.Message);
                    return false;
                }
            }
        }

        public static byte[] AesCrypt(
          byte[] keyBytes,
          byte[] ivBytes,
          byte[] inputBytes,
          CryptMode cryptMode)
        {
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Key = keyBytes;
                rijndaelManaged.IV = ivBytes;
                rijndaelManaged.Padding = PaddingMode.None;
                using (ICryptoTransform cryptoTransform = CreateCryptoTransform(rijndaelManaged))
                    return cryptoTransform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            ICryptoTransform CreateCryptoTransform(RijndaelManaged rijndaelManaged)
            {
                switch (cryptMode)
                {
                    case CryptMode.Encrypt:
                        return rijndaelManaged.CreateEncryptor();
                    case CryptMode.Decrypt:
                        return rijndaelManaged.CreateDecryptor();
                    default:
                        throw new InvalidOperationException(string.Format("Unsupported crypt mode {0}.", (object)cryptMode));
                }
            }
        }
    }
}
