using System.Collections;
using System.Collections.Generic;

namespace MongoDB.Libmongocrypt
{
    public class KmsRequestCollection :
      IReadOnlyCollection<KmsRequest>,
      IEnumerable<KmsRequest>,
      IEnumerable
    {
        private List<KmsRequest> _requests;
        private CryptContext _parent;

        internal KmsRequestCollection(List<KmsRequest> requests, CryptContext parent)
        {
            this._requests = requests;
            this._parent = parent;
        }

        int IReadOnlyCollection<KmsRequest>.Count => this._requests.Count;

        IEnumerator<KmsRequest> IEnumerable<KmsRequest>.GetEnumerator() => (IEnumerator<KmsRequest>)this._requests.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this._requests.GetEnumerator();

        public void MarkDone() => this._parent.MarkKmsDone();
    }
}
