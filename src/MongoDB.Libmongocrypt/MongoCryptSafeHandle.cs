using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal class MongoCryptSafeHandle : SafeHandle
    {
        private MongoCryptSafeHandle()
          : base(IntPtr.Zero, true)
        {
        }

        public void Check(Status status, bool success)
        {
            if (success)
                return;
            int num = Library.mongocrypt_status(this, status.Handle) ? 1 : 0;
            status.ThrowExceptionIfNeeded();
        }

        public override bool IsInvalid => this.handle == IntPtr.Zero;

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            Library.mongocrypt_destroy(this.handle);
            return true;
        }
    }
}
