using System;

namespace MongoDB.Libmongocrypt
{
    public class LibraryLoadingException : Exception
    {
        public LibraryLoadingException(string message)
          : base(message)
        {
        }
    }
}
