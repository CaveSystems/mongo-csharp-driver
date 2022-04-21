using System;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    public class CryptClient : IDisposable, IStatus
    {
        private MongoCryptSafeHandle _handle;
        private Status _status;

        internal CryptClient(MongoCryptSafeHandle handle, Status status)
        {
            this._handle = handle;
            this._status = status;
        }

        public CryptContext StartCreateDataKeyContext(KmsKeyId keyId)
        {
            ContextSafeHandle contextSafeHandle = Library.mongocrypt_ctx_new(this._handle);
            keyId.SetCredentials(contextSafeHandle, this._status);
            contextSafeHandle.Check(this._status, Library.mongocrypt_ctx_datakey_init(contextSafeHandle));
            return new CryptContext(contextSafeHandle);
        }

        public unsafe CryptContext StartEncryptionContext(string db, byte[] command)
        {
            ContextSafeHandle handle = Library.mongocrypt_ctx_new(this._handle);
            IntPtr hglobalAnsi = Marshal.StringToHGlobalAnsi(db);
            try
            {
                fixed (byte* numPtr = command)
                {
                    using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)command.Length))
                        handle.Check(this._status, Library.mongocrypt_ctx_encrypt_init(handle, hglobalAnsi, -1, pinnedBinary.Handle));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(hglobalAnsi);
            }
            return new CryptContext(handle);
        }

        public unsafe CryptContext StartExplicitEncryptionContextWithKeyId(
          byte[] keyId,
          string encryptionAlgorithm,
          byte[] message)
        {
            ContextSafeHandle handle = Library.mongocrypt_ctx_new(this._handle);
            fixed (byte* numPtr = keyId)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)keyId.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_setopt_key_id(handle, pinnedBinary.Handle));
            }
            handle.Check(this._status, Library.mongocrypt_ctx_setopt_algorithm(handle, encryptionAlgorithm, -1));
            fixed (byte* numPtr = message)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)message.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_explicit_encrypt_init(handle, pinnedBinary.Handle));
            }
            return new CryptContext(handle);
        }

        public unsafe CryptContext StartExplicitEncryptionContextWithKeyAltName(
          byte[] keyAltName,
          string encryptionAlgorithm,
          byte[] message)
        {
            ContextSafeHandle handle = Library.mongocrypt_ctx_new(this._handle);
            fixed (byte* numPtr = keyAltName)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)keyAltName.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_setopt_key_alt_name(handle, pinnedBinary.Handle));
            }
            handle.Check(this._status, Library.mongocrypt_ctx_setopt_algorithm(handle, encryptionAlgorithm, -1));
            fixed (byte* numPtr = message)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)message.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_explicit_encrypt_init(handle, pinnedBinary.Handle));
            }
            return new CryptContext(handle);
        }

        public unsafe CryptContext StartDecryptionContext(byte[] buffer)
        {
            ContextSafeHandle handle = Library.mongocrypt_ctx_new(this._handle);
            GCHandle.Alloc((object)buffer, GCHandleType.Pinned);
            fixed (byte* numPtr = buffer)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)buffer.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_decrypt_init(handle, pinnedBinary.Handle));
            }
            return new CryptContext(handle);
        }

        public unsafe CryptContext StartExplicitDecryptionContext(byte[] buffer)
        {
            ContextSafeHandle handle = Library.mongocrypt_ctx_new(this._handle);
            fixed (byte* numPtr = buffer)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)buffer.Length))
                    handle.Check(this._status, Library.mongocrypt_ctx_explicit_decrypt_init(handle, pinnedBinary.Handle));
            }
            return new CryptContext(handle);
        }

        void IStatus.Check(Status status)
        {
            int num = Library.mongocrypt_status(this._handle, status.Handle) ? 1 : 0;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._handle == null || this._handle.IsInvalid)
                return;
            this._handle.Dispose();
        }

        private void Check(bool success)
        {
            if (success)
                return;
            this._status.Check((IStatus)this);
        }
    }
}
