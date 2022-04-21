using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    public class Binary : IDisposable
    {
        private BinarySafeHandle _handle;

        internal Binary() => this._handle = Library.mongocrypt_binary_new();

        internal Binary(BinarySafeHandle handle) => this._handle = handle;

        public IntPtr Data => Library.mongocrypt_binary_data(this._handle);

        public uint Length => Library.mongocrypt_binary_len(this._handle);

        internal BinarySafeHandle Handle => this._handle;

        public byte[] ToArray()
        {
            byte[] destination = new byte[(int)this.Length];
            Marshal.Copy(this.Data, destination, 0, destination.Length);
            return destination;
        }

        public void WriteBytes(byte[] bytes)
        {
            if ((long)bytes.Length > (long)this.Length)
                throw new InvalidDataException(string.Format("Incorrect bytes size {0}. The bytes size must be less than or equal to {1}.", (object)bytes.Length, (object)this.Length));
            Marshal.Copy(bytes, 0, this.Data, bytes.Length);
        }

        public override string ToString() => Marshal.PtrToStringAnsi(this.Data);

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
    }
}
