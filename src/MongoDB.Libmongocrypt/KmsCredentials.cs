using System;

namespace MongoDB.Libmongocrypt
{
    public class KmsCredentials
    {
        private readonly byte[] _credentialsBytes;

        public KmsCredentials(byte[] credentialsBytes) => this._credentialsBytes = credentialsBytes ?? throw new ArgumentNullException(nameof(credentialsBytes));

        internal unsafe void SetCredentials(MongoCryptSafeHandle handle, Status status)
        {
            fixed (byte* numPtr = this._credentialsBytes)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)this._credentialsBytes.Length))
                    handle.Check(status, Library.mongocrypt_setopt_kms_providers(handle, pinnedBinary.Handle));
            }
        }
    }
}
