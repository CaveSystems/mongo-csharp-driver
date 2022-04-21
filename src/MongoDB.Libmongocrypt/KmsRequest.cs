using System;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    public class KmsRequest : IStatus
    {
        private readonly Status _status;
        private readonly IntPtr _id;

        internal KmsRequest(IntPtr id)
        {
            this._id = id;
            this._status = new Status();
        }

        public uint BytesNeeded => Library.mongocrypt_kms_ctx_bytes_needed(this._id);

        public string Endpoint
        {
            get
            {
                IntPtr zero = IntPtr.Zero;
                this.Check(Library.mongocrypt_kms_ctx_endpoint(this._id, ref zero));
                return Marshal.PtrToStringAnsi(zero);
            }
        }

        public string KmsProvider
        {
            get
            {
                uint length;
                return Marshal.PtrToStringAnsi(Library.mongocrypt_kms_ctx_get_kms_provider(this._id, out length));
            }
        }

        public Binary Message
        {
            get
            {
                Binary binary = new Binary();
                this.Check(Library.mongocrypt_kms_ctx_message(this._id, binary.Handle));
                return binary;
            }
        }

        public unsafe void Feed(byte[] buffer)
        {
            fixed (byte* numPtr = buffer)
            {
                using (PinnedBinary pinnedBinary = new PinnedBinary((IntPtr)(void*)numPtr, (uint)buffer.Length))
                    this.Check(Library.mongocrypt_kms_ctx_feed(this._id, pinnedBinary.Handle));
            }
        }

        void IStatus.Check(Status status)
        {
            int num = Library.mongocrypt_kms_ctx_status(this._id, status.Handle) ? 1 : 0;
        }

        private void Check(bool success)
        {
            if (success)
                return;
            this._status.Check((IStatus)this);
        }
    }
}
