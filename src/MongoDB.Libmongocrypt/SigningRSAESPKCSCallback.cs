using System;
using System.Security.Cryptography;

namespace MongoDB.Libmongocrypt
{
    internal static class SigningRSAESPKCSCallback
    {
        public static bool RsaSign(
          IntPtr ctx,
          IntPtr key,
          IntPtr inData,
          IntPtr outData,
          IntPtr statusPtr)
        {
            using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
            {
                try
                {
                    Binary binary1 = new Binary(BinarySafeHandle.FromIntPtr(key));
                    Binary binary2 = new Binary(BinarySafeHandle.FromIntPtr(inData));
                    new Binary(BinarySafeHandle.FromIntPtr(outData)).WriteBytes(SigningRSAESPKCSCallback.HashAndSignBytes(binary2.ToArray(), binary1.ToArray()));
                    return true;
                }
                catch (Exception ex)
                {
                    status.SetStatus(1U, ex.Message);
                    return false;
                }
            }
        }

#if NETSTANDARD2_1_OR_GREATER
        public static byte[] HashAndSignBytes(byte[] dataToSign, byte[] key)
        {
            using (RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider())
            {
                cryptoServiceProvider.ImportPkcs8PrivateKey((ReadOnlySpan<byte>)key, out int _);
                return cryptoServiceProvider.SignData(dataToSign, (object)SHA256.Create());
            }
        }
#else
        public static byte[] HashAndSignBytes(byte[] dataToSign, byte[] key) => throw new PlatformNotSupportedException("RSACryptoServiceProvider.ImportPkcs8PrivateKey is supported only on frameworks higher or equal to .netstandard2.1.");
#endif
    }
}
