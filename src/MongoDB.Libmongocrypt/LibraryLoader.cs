using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MongoDB.Libmongocrypt
{
    internal class LibraryLoader
    {
        private LibraryLoader.ISharedLibraryLoader _loader;

        public LibraryLoader()
        {
            if (!Environment.Is64BitProcess)
                throw new PlatformNotSupportedException(this.GetType().Namespace + " needs to be run in a 64-bit process.");
            List<string> stringList = new List<string>();
            stringList.Add(Path.GetDirectoryName(typeof(LibraryLoader).GetTypeInfo().Assembly.Location));
            switch (OperatingSystemHelper.CurrentOperatingSystem)
            {
                case OperatingSystemPlatform.Windows:
                    string[] suffixPaths1 = new string[3]
                    {
            "..\\..\\runtimes\\win\\native\\",
            ".\\runtimes\\win\\native\\",
            string.Empty
                    };
                    this._loader = (LibraryLoader.ISharedLibraryLoader)new LibraryLoader.WindowsLibrary(this.FindLibrary((IList<string>)stringList, suffixPaths1, "mongocrypt.dll"));
                    break;
                case OperatingSystemPlatform.Linux:
                    string[] suffixPaths2 = new string[3]
                    {
            "../../runtimes/linux/native/",
            "runtimes/linux/native/",
            string.Empty
                    };
                    this._loader = (LibraryLoader.ISharedLibraryLoader)new LibraryLoader.LinuxLibrary(this.FindLibrary((IList<string>)stringList, suffixPaths2, "libmongocrypt.so"));
                    break;
                case OperatingSystemPlatform.MacOS:
                    string[] suffixPaths3 = new string[3]
                    {
            "../../runtimes/osx/native/",
            "runtimes/osx/native/",
            string.Empty
                    };
                    this._loader = (LibraryLoader.ISharedLibraryLoader)new LibraryLoader.DarwinLibraryLoader(this.FindLibrary((IList<string>)stringList, suffixPaths3, "libmongocrypt.dylib"));
                    break;
                default:
                    throw new PlatformNotSupportedException("Unsupported operating system.");
            }
        }

        private string FindLibrary(IList<string> basePaths, string[] suffixPaths, string library)
        {
            List<string> stringList = new List<string>();
            foreach (string basePath in (IEnumerable<string>)basePaths)
            {
                foreach (string suffixPath in suffixPaths)
                {
                    string path = Path.Combine(basePath, suffixPath, library);
                    if (File.Exists(path))
                        return path;
                    stringList.Add(path);
                }
            }
            throw new FileNotFoundException("Could not find: " + library + " --\n Tried: " + string.Join(",", (IEnumerable<string>)stringList));
        }

        public T GetFunction<T>(string name)
        {
            IntPtr function = this._loader.GetFunction(name);
            return !(function == IntPtr.Zero) ? Marshal.GetDelegateForFunctionPointer<T>(function) : throw new LibraryLoader.FunctionNotFoundException(name);
        }

        public class FunctionNotFoundException : Exception
        {
            public FunctionNotFoundException(string message)
              : base(message)
            {
            }
        }

        private interface ISharedLibraryLoader
        {
            IntPtr GetFunction(string name);
        }

        private class DarwinLibraryLoader : LibraryLoader.ISharedLibraryLoader
        {
            public const int RTLD_GLOBAL = 8;
            public const int RTLD_NOW = 2;
            private readonly IntPtr _handle;

            public DarwinLibraryLoader(string path)
            {
                this._handle = LibraryLoader.DarwinLibraryLoader.dlopen(path, 10);
                if (this._handle == IntPtr.Zero)
                    throw new FileNotFoundException(path);
            }

            public IntPtr GetFunction(string name) => LibraryLoader.DarwinLibraryLoader.dlsym(this._handle, name);

            [DllImport("libdl")]
            public static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);
        }

        private class LinuxLibrary : LibraryLoader.ISharedLibraryLoader
        {
            public const int RTLD_GLOBAL = 256;
            public const int RTLD_NOW = 2;
            private readonly IntPtr _handle;

            public LinuxLibrary(string path)
            {
                this._handle = LibraryLoader.LinuxLibrary.dlopen(path, 258);
                if (this._handle == IntPtr.Zero)
                    throw new FileNotFoundException(path);
            }

            public IntPtr GetFunction(string name) => LibraryLoader.LinuxLibrary.dlsym(this._handle, name);

            [DllImport("libdl")]
            public static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr dlsym(IntPtr handle, string symbol);
        }

        private class WindowsLibrary : LibraryLoader.ISharedLibraryLoader
        {
            private readonly IntPtr _handle;

            public WindowsLibrary(string path)
            {
                this._handle = LibraryLoader.WindowsLibrary.LoadLibrary(path);
                if (this._handle == IntPtr.Zero)
                {
                    int lastWin32Error = Marshal.GetLastWin32Error();
                    throw new LibraryLoadingException(path + ", Windows Error: " + lastWin32Error.ToString());
                }
            }

            public IntPtr GetFunction(string name) => LibraryLoader.WindowsLibrary.GetProcAddress(this._handle, name);

            [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

            [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        }
    }
}
