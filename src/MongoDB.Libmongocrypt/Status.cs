using System;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal class Status : IDisposable
    {
        private StatusSafeHandle _handle;

        public Status() => this._handle = Library.mongocrypt_status_new();

        public Status(StatusSafeHandle handle) => this._handle = handle;

        public void Check(IStatus status)
        {
            status.Check(this);
            this.ThrowExceptionIfNeeded();
        }

        public void SetStatus(uint code, string msg)
        {
            IntPtr hglobalAnsi = Marshal.StringToHGlobalAnsi(msg);
            try
            {
                Library.mongocrypt_status_set(this._handle, 1, code, hglobalAnsi, -1);
            }
            finally
            {
                Marshal.FreeHGlobal(hglobalAnsi);
            }
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

        internal StatusSafeHandle Handle => this._handle;

        internal void ThrowExceptionIfNeeded()
        {
            if (!Library.mongocrypt_status_ok(this._handle))
            {
                int num1 = (int)Library.mongocrypt_status_type(this._handle);
                uint num2 = Library.mongocrypt_status_code(this._handle);
                uint length;
                string stringAnsi = Marshal.PtrToStringAnsi(Library.mongocrypt_status_message(this._handle, out length));
                int num3 = (int)num2;
                string message = stringAnsi;
                throw new CryptException((Library.StatusType)num1, (uint)num3, message);
            }
        }
    }
}
