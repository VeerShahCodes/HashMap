using System.Collections;

namespace Hashmapu
{
    public class HashMap<TKey,TValue> : IDictionary
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] arr;
        public object? this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        //CONSTRUCTOR
        public HashMap(LinkedList<KeyValuePair<TKey, TValue>>[] arr)
        {
            this.arr = arr;
            
        }
        //METHODS
        public void Add(object key, object? value)
        {
            if(key.GetType() is TKey && value.GetType() is TValue) //only works if the key and value of are a valid type
            {
                int hashCode = key.GetHashCode();
                int index = hashCode % arr.Length;
                KeyValuePair<TKey, TValue> addition = new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value);
                if (arr[index] == null) //checks if there is no linked list at this index and adds a new linked list
                {
                    arr[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    arr[index].AddLast(addition);

                }
                else
                {
                    //check if there is already key of this key in the linked list
                    bool containsKey = false;
                    foreach (var item in arr[index])
                    {
                        if(item.Key.Equals((TKey)key))
                        {
                            containsKey = true;
                            break;
                        }
                    }

                    if(containsKey) //if there is already key of this key
                    {
                        throw new Exception();
                    }
                    else//otherwise add new key value pair to list
                    {
                        arr[index].AddLast(addition);
                    }
                    
                }
            }
            else
            {
                throw new TypeAccessException();
            }

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
