using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Libmongocrypt
{
    public class KmsKeyId
    {
        private readonly IReadOnlyList<byte[]> _alternateKeyNameBytes;
        private readonly byte[] _dataKeyOptionsBytes;

        public KmsKeyId(byte[] dataKeyOptionsBytes, IEnumerable<byte[]> alternateKeyNameBytes = null)
        {
            this._dataKeyOptionsBytes = dataKeyOptionsBytes ?? throw new ArgumentNullException(nameof(dataKeyOptionsBytes));
            this._alternateKeyNameBytes = (IReadOnlyList<byte[]>)(alternateKeyNameBytes ?? Enumerable.Empty<byte[]>()).ToList<byte[]>().AsReadOnly();
        }

        public IReadOnlyList<byte[]> AlternateKeyNameBytes => this._alternateKeyNameBytes;

        internal unsafe void SetAlternateKeyNames(ContextSafeHandle context, Status status)
        {
            foreach (byte[] alternateKeyNameByte in (IEnumerable<byte[]>)this._alternateKeyNameBytes)
            {
                fixed (byte* numPtr = alternateKeyNameByte)
                {
                    using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)alternateKeyNameByte.Length))
                        context.Check(status, Library.mongocrypt_ctx_setopt_key_alt_name(context, pinnedBinary.Handle));
                }
            }
        }

        internal unsafe void SetCredentials(ContextSafeHandle context, Status status)
        {
            fixed (byte* numPtr = this._dataKeyOptionsBytes)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)this._dataKeyOptionsBytes.Length))
                    context.Check(status, Library.mongocrypt_ctx_setopt_key_encryption_key(context, pinnedBinary.Handle));
            }
            this.SetAlternateKeyNames(context, status);
        }
    }
}
