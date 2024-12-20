
using System.Collections;
using System.Collections.Generic;


namespace DictionaryDS
{
    public class CustomDictionary<TKey, TValue> : IEnumerable, IEnumerator
    {
        //Count Private
        private int _count;
        //Capacity Size of the Dict Array
        private int _capacity;
        //Count Public
        public int Count { get { return _count; } }
        //Dictionary Stored Inside the Array
        //A dictionary is created as a Class
        //With Type Key, Pair
        private KeyValue<TKey, TValue>[] _array;

        //To get the value with the Key
        public TValue this[TKey key]
        {
            get
            {
                //Get the value with Key using Linear Search Out keyword
                // if not found default value is returned
                TValue value = default(TValue);
                LinearSearch(key, out value);
                return value;
            }
            set
            {
                //To set the value at the _array position
                int position = LinearSearch(key, out TValue value1);
                if (position > -1)
                {
                    _array[position].Value = value;
                }
            }
        }


        public CustomDictionary()
        {
            _capacity = 4;
            _count = 0;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }

        public CustomDictionary(int size)
        {
            _capacity = size;
            _count = 0;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }

        public void Add(TKey key, TValue value1)
        {
            //If count==capacity Increase Size 2 times
            if (_count == _capacity)
            {
                GrowSize();
            }
            //To check if key is unique
            int position = LinearSearch(key, out TValue value2);
            //Only unique keys are valid
            if (position == -1)
            {
                KeyValue<TKey, TValue> temp = new KeyValue<TKey, TValue>();
                temp.Key = key;
                temp.Value = value1;
                _array[_count] = temp;
                //Increase Count
                _count++;
            }

        }
        //To Check an Key Exists or not
        public bool ContainsKey(TKey key)
        {
            int position = LinearSearch(key, out TValue value);
            if (position != -1)
            {
                return true;
            }
            return false;
        }

        //To Check an Value exists or Not
        public bool ContainsValue(TValue value1)
        {
            int position = LinearSearchValue(value1);
            if (position != -1)
            {
                return true;
            }
            return false;
        }

        //To Increase Size of capacity
        void GrowSize()
        {
            _capacity = _capacity * 2;
            KeyValue<TKey, TValue>[] temp = new KeyValue<TKey, TValue>[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        //To clear the data in the dictionary
        public void Clear()
        {
            _capacity = 4;
            _count = 0;
            KeyValue<TKey, TValue>[] temp = new KeyValue<TKey, TValue>[_capacity];
            _array = temp;
        }
        //To Remove a Dictionary Key Value
        //To change value 
        public void Remove(TKey key)
        {
            _capacity = _capacity - 1;
            int position = LinearSearch(key, out TValue value);
            if (position > -1)
            {
                for (int i = 0; i <_count - 1; i++)
                {
                    if (i >= position)
                {
                    _array[i] = _array[i + 1];
                }
                }
                _count--;
            }

        }
        int LinearSearch(TKey key, out TValue value)
        {
            int position = -1;
            value = default(TValue);
            for (int i = 0; i < _count; i++)
            {
                if (key.Equals(_array[i].Key))
                {
                    position = i;
                    value = _array[i].Value;
                    break;
                }
            }
            return position;
        }

        //Linear Search to find Value
        int LinearSearchValue(TValue value)
        {
            int position = -1;
            for (int i = 0; i < _count; i++)
            {
                if (value.Equals(_array[i].Value))
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        int position;
        //For Each Looping
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current { get { return _array[position]; } }
    }
}