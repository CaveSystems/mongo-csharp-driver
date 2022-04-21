using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MongoDB.Libmongocrypt
{
    public class CryptOptions
    {
        public IReadOnlyList<MongoDB.Libmongocrypt.KmsCredentials> KmsCredentials { get; }

        public byte[] Schema { get; }

        public CryptOptions(IEnumerable<MongoDB.Libmongocrypt.KmsCredentials> credentials)
          : this(credentials, (byte[])null)
        {
        }

        public CryptOptions(IEnumerable<MongoDB.Libmongocrypt.KmsCredentials> credentials, byte[] schema)
        {
            this.KmsCredentials = (IReadOnlyList<MongoDB.Libmongocrypt.KmsCredentials>)new ReadOnlyCollection<MongoDB.Libmongocrypt.KmsCredentials>((IList<MongoDB.Libmongocrypt.KmsCredentials>)(credentials ?? throw new ArgumentNullException(nameof(credentials))).ToList<MongoDB.Libmongocrypt.KmsCredentials>());
            this.Schema = schema;
        }
    }
}
