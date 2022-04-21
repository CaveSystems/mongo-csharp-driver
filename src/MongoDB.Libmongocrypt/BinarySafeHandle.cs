using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal class BinarySafeHandle : SafeHandle
    {
        private BinarySafeHandle()
          : base(IntPtr.Zero, true)
        {
        }

        private BinarySafeHandle(IntPtr ptr)
          : base(ptr, false)
        {
        }

        public static BinarySafeHandle FromIntPtr(IntPtr ptr) => new BinarySafeHandle(ptr);

        public override bool IsInvalid => this.handle == IntPtr.Zero;

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            Library.mongocrypt_binary_destroy(this.handle);
            return true;
        }
    }
}
