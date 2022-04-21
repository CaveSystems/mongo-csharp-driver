using System;
using System.Collections.Generic;

namespace MongoDB.Libmongocrypt
{
    public class CryptContext : IDisposable, IStatus
    {
        private ContextSafeHandle _handle;
        private Status _status;

        internal CryptContext(ContextSafeHandle handle)
        {
            this._handle = handle;
            this._status = new Status();
        }

        public CryptContext.StateCode State => Library.mongocrypt_ctx_state(this._handle);

        public bool IsDone => this.State == CryptContext.StateCode.MONGOCRYPT_CTX_DONE;

        public Binary GetOperation()
        {
            Binary binary = new Binary();
            this.Check(Library.mongocrypt_ctx_mongo_op(this._handle, binary.Handle));
            return binary;
        }

        public unsafe void Feed(byte[] buffer)
        {
            fixed (byte* numPtr = buffer)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)buffer.Length))
                    this.Check(Library.mongocrypt_ctx_mongo_feed(this._handle, pinnedBinary.Handle));
            }
        }

        public void MarkDone() => this.Check(Library.mongocrypt_ctx_mongo_done(this._handle));

        public Binary FinalizeForEncryption()
        {
            Binary binary = new Binary();
            this.Check(Library.mongocrypt_ctx_finalize(this._handle, binary.Handle));
            return binary;
        }

        public KmsRequestCollection GetKmsMessageRequests()
        {
            List<KmsRequest> requests = new List<KmsRequest>();
            for (IntPtr id = Library.mongocrypt_ctx_next_kms_ctx(this._handle); id != IntPtr.Zero; id = Library.mongocrypt_ctx_next_kms_ctx(this._handle))
                requests.Add(new KmsRequest(id));
            return new KmsRequestCollection(requests, this);
        }

        void IStatus.Check(Status status)
        {
            int num = Library.mongocrypt_ctx_status(this._handle, status.Handle) ? 1 : 0;
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

        internal void MarkKmsDone() => this.Check(Library.mongocrypt_ctx_kms_done(this._handle));

        private void Check(bool success)
        {
            if (success)
                return;
            this._status.Check((IStatus)this);
        }

        public enum StateCode
        {
            MONGOCRYPT_CTX_ERROR,
            MONGOCRYPT_CTX_NEED_MONGO_COLLINFO,
            MONGOCRYPT_CTX_NEED_MONGO_MARKINGS,
            MONGOCRYPT_CTX_NEED_MONGO_KEYS,
            MONGOCRYPT_CTX_NEED_KMS,
            MONGOCRYPT_CTX_READY,
            MONGOCRYPT_CTX_DONE,
        }
    }
}
