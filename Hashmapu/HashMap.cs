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

        private int count;
        public int Count => count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        //CONSTRUCTOR
        public HashMap(LinkedList<KeyValuePair<TKey, TValue>>[] arr)
        {
            this.arr = arr;
            count = 0;
            count += (int)arr.LongLength;
            
        }
        //METHODS
        public void Add(object key, object? value)
        {
            if(key.GetType() is TKey && value?.GetType() is TValue) //only works if the key and value of are a valid type
            {
                int hashCode = key.GetHashCode();
                int index = hashCode % arr.Length;
                KeyValuePair<TKey, TValue> addition = new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value);
                if (arr[index] == null) //checks if there is no linked list at this index and adds a new linked list
                {
                    arr[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    arr[index].AddLast(addition);
                    count++;

                }
                else
                {
                    //check if there is already key of this key in the linked list
                    bool containsKey = false;
                    foreach (var item in arr[index])
                    {
                        if(item.Key!.Equals((TKey)key))
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
                        count++;
                    }
                    
                }
            }
            else
            {
                throw new TypeAccessException();
            }

        }

        public void ReHash()
        {
            bool needsToRehash = false;
            foreach(var item in arr)
            {
                if(item.Count == Count) //checks if count of current linked list == count of hashmap and then decides to rehash or not
                {
                    needsToRehash = true;
                    break;
                }
            }
            if (!needsToRehash) return;

            LinkedList<KeyValuePair<TKey, TValue>>[] newArr = new LinkedList<KeyValuePair<TKey, TValue>>[arr.Length * 2]; //creates a new hashmap double the size to rehash

            foreach(var LList in arr)//adds each keypair value into the new hashmap array
            {
                foreach (var item in LList)
                {
                    int hashCode = item.Key!.GetHashCode();
                    int index = hashCode % newArr.Length;
                    if (newArr[index] == null) //checks if there is no linked list at this index and adds a new linked list
                    {
                        newArr[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                        newArr[index].AddLast(item);
                    }
                    else
                    {
                        newArr[index].AddLast(item);
                    }
                }
            }

            arr = newArr; //sets the new hashmap to the old one



        }

        public void Clear()
        {
            arr = new LinkedList<KeyValuePair<TKey, TValue>>[arr.Length]; //creates a new hashmap of the same size
        }

        public bool Contains(object key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % arr.Length;
            if (arr[index] != null)
            {
                foreach (var item in arr[index])
                {
                    if (item.Key!.Equals((TKey)key)) //if found
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;

        }

        public void CopyTo(Array array, int index)
        {
            if(array is not LinkedList<KeyValuePair<TKey, TValue>>[] arr)
            {
                throw new ArgumentException();
            }
            else //only runs if its an array of linked lists
            {
                foreach (var LList in arr)
                {
                    foreach (var item in LList)
                    {
                        array.SetValue(item, index);//copies the value into the array at the index
                        index++;
                    }
                }
            }

            
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % arr.Length;
            if (arr[index] != null) //checks if there is a linked list at this index
            {
                foreach (var item in arr[index])
                {
                    if (item.Key!.Equals((TKey)key))//if current keyval has a key of this key
                    {
                        arr[index].Remove(item); //remove
                        count--;
                        return;
                    }
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
