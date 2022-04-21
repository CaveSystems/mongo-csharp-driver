using System;
using System.Collections.Generic;

namespace MongoDB.Libmongocrypt
{
    public class CryptClientFactory
    {
        private static Library.Delegates.CryptoCallback __crypto256DecryptCallback = new Library.Delegates.CryptoCallback(CipherCallbacks.Decrypt);
        private static Library.Delegates.CryptoCallback __crypto256EncryptCallback = new Library.Delegates.CryptoCallback(CipherCallbacks.Encrypt);
        private static Library.Delegates.HashCallback __cryptoHashCallback = new Library.Delegates.HashCallback(HashCallback.Hash);
        private static Library.Delegates.CryptoHmacCallback __cryptoHmacSha256Callback = new Library.Delegates.CryptoHmacCallback(HmacShaCallbacks.HmacSha256);
        private static Library.Delegates.CryptoHmacCallback __cryptoHmacSha512Callback = new Library.Delegates.CryptoHmacCallback(HmacShaCallbacks.HmacSha512);
        private static Library.Delegates.RandomCallback __randomCallback = new Library.Delegates.RandomCallback(SecureRandomCallback.GenerateRandom);
        private static Library.Delegates.CryptoHmacCallback __signRsaesPkcs1HmacCallback = new Library.Delegates.CryptoHmacCallback(SigningRSAESPKCSCallback.RsaSign);

        public static unsafe CryptClient Create(CryptOptions options)
        {
            MongoCryptSafeHandle handle = Library.mongocrypt_new();
            Status status = new Status();
            if (OperatingSystemHelper.CurrentOperatingSystem != OperatingSystemPlatform.Windows)
            {
                handle.Check(status, Library.mongocrypt_setopt_crypto_hooks(handle, CryptClientFactory.__crypto256EncryptCallback, CryptClientFactory.__crypto256DecryptCallback, CryptClientFactory.__randomCallback, CryptClientFactory.__cryptoHmacSha512Callback, CryptClientFactory.__cryptoHmacSha256Callback, CryptClientFactory.__cryptoHashCallback, IntPtr.Zero));
                handle.Check(status, Library.mongocrypt_setopt_crypto_hook_sign_rsaes_pkcs1_v1_5(handle, CryptClientFactory.__signRsaesPkcs1HmacCallback, IntPtr.Zero));
            }
            foreach (KmsCredentials kmsCredential in (IEnumerable<KmsCredentials>)options.KmsCredentials)
                kmsCredential.SetCredentials(handle, status);
            if (options.Schema != null)
            {
                fixed (byte* numPtr = options.Schema)
                {
                    using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)options.Schema.Length))
                        handle.Check(status, Library.mongocrypt_setopt_schema_map(handle, pinnedBinary.Handle));
                }
            }
            int num = Library.mongocrypt_init(handle) ? 1 : 0;
            return new CryptClient(handle, status);
        }
    }
}
