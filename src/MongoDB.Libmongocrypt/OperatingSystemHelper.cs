using System;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal static class OperatingSystemHelper
    {
        public static OperatingSystemPlatform CurrentOperatingSystem
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return OperatingSystemPlatform.MacOS;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return OperatingSystemPlatform.Linux;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return OperatingSystemPlatform.Windows;
                throw new PlatformNotSupportedException("Unsupported platform '" + RuntimeInformation.OSDescription + "'.");
            }
        }
    }
}
