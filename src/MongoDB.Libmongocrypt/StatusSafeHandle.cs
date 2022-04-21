using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal class StatusSafeHandle : SafeHandle
    {
        private StatusSafeHandle()
          : base(IntPtr.Zero, true)
        {
        }

        private StatusSafeHandle(IntPtr ptr)
          : base(ptr, false)
        {
        }

        public static StatusSafeHandle FromIntPtr(IntPtr ptr) => new StatusSafeHandle(ptr);

        public override bool IsInvalid => this.handle == IntPtr.Zero;

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            Library.mongocrypt_status_destroy(this.handle);
            return true;
        }
    }
}
