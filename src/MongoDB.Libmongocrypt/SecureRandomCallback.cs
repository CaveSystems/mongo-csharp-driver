using System;
using System.Security.Cryptography;

namespace MongoDB.Libmongocrypt
{
    internal static class SecureRandomCallback
    {
        public static bool GenerateRandom(IntPtr ctx, IntPtr @out, uint count, IntPtr statusPtr)
        {
            using (Binary binary = new Binary(BinarySafeHandle.FromIntPtr(@out)))
            {
                using (Status status = new Status(StatusSafeHandle.FromIntPtr(statusPtr)))
                {
                    try
                    {
                        using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
                        {
                            byte[] numArray = new byte[(int)count];
                            randomNumberGenerator.GetBytes(numArray);
                            binary.WriteBytes(numArray);
                            return true;
                        }
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
}
