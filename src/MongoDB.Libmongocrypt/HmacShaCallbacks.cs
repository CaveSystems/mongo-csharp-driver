using System;
using System.Security.Cryptography;

namespace MongoDB.Libmongocrypt
{
    internal static class HmacShaCallbacks
    {
        public static bool HmacSha512(
          IntPtr ctx,
          IntPtr key,
          IntPtr @in,
          IntPtr @out,
          IntPtr statusPtr)
        {
            return HmacShaCallbacks.Hmac(key, @in, @out, statusPtr, 512);
        }

        public static bool HmacSha256(
          IntPtr ctx,
          IntPtr key,
          IntPtr @in,
          IntPtr @out,
          IntPtr statusPtr)
        {
            return HmacShaCallbacks.Hmac(key, @in, @out, statusPtr, 256);
        }

        public static byte[] CalculateHash(byte[] keyBytes, byte[] inputBytes, int bitness)
        {
            using (HMAC hmacByBitness = HmacShaCallbacks.GetHmacByBitness(bitness, keyBytes))
            {
                hmacByBitness.Initialize();
                hmacByBitness.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return hmacByBitness.Hash;
            }
        }

        private static HMAC GetHmacByBitness(int bitness, byte[] keyBytes)
        {
            if (bitness == 256)
                return (HMAC)new HMACSHA256(keyBytes);
            if (bitness == 512)
                return (HMAC)new HMACSHA512(keyBytes);
            throw new ArgumentOutOfRangeException(string.Format("The bitness {0} is unsupported.", (object)bitness));
        }

        private static bool Hmac(IntPtr key, IntPtr @in, IntPtr @out, IntPtr statusPtr, int bitness)
        {
            using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
            {
                try
                {
                    Binary binary1 = new Binary(BinarySafeHandle.FromIntPtr(key));
                    Binary binary2 = new Binary(BinarySafeHandle.FromIntPtr(@in));
                    new Binary(BinarySafeHandle.FromIntPtr(@out)).WriteBytes(HmacShaCallbacks.CalculateHash(binary1.ToArray(), binary2.ToArray(), bitness));
                    return true;
                }
                catch (Exception ex)
                {
                    status.SetStatus(1U, ex.Message);
                    return false;
                }
            }
        }
    }
}
