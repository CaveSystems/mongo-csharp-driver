using System;
using System.Security.Cryptography;

namespace MongoDB.Libmongocrypt
{
    internal static class HashCallback
    {
        public static bool Hash(IntPtr ctx, IntPtr @in, IntPtr @out, IntPtr statusPtr)
        {
            using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
            {
                try
                {
                    Binary binary = new Binary(BinarySafeHandle.FromIntPtr(@in));
                    new Binary(BinarySafeHandle.FromIntPtr(@out)).WriteBytes(HashCallback.CalculateHash(binary.ToArray()));
                    return true;
                }
                catch (Exception ex)
                {
                    status.SetStatus(1U, ex.Message);
                    return false;
                }
            }
        }

        public static byte[] CalculateHash(byte[] inputBytes)
        {
            using (SHA256 shA256 = SHA256.Create())
            {
                shA256.Initialize();
                shA256.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return shA256.Hash;
            }
        }
    }
}
