using System;

namespace MongoDB.Libmongocrypt
{
    internal class PinnedBinary : Binary
    {
        internal PinnedBinary(IntPtr ptr, uint len)
          : base(Library.mongocrypt_binary_new_from_data(ptr, len))
        {
        }
    }
}
