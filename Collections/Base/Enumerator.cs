using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    public class Enumerator<T> : IEnumerator<T>
    {
        private Collection<T> collection;
        private int index;

        public T Current => collection[index];

        object IEnumerator.Current => collection[index];

        public bool MoveNext()
        {
            index++;
            return index < collection.Count - 1;
        }

        public void Reset()
        {
            index = 0;
        }

        public void Dispose()
        {
            
        }

        internal Enumerator(Collection<T> collection)
        {
            this.collection = collection;
        }
    }
}
