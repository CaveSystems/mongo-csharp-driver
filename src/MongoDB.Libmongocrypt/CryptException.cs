using System;

namespace MongoDB.Libmongocrypt
{
    public class CryptException : Exception
    {
        private readonly uint _code;
        private readonly Library.StatusType _statusType;

        internal CryptException(Library.StatusType statusType, uint code, string message)
          : base(message)
        {
            this._code = code;
            this._statusType = statusType;
        }
    }
}
