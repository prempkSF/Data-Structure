using System.Collections;


namespace QueueDS
{
    public class CustomQueue<Type> : IEnumerable, IEnumerator
    {
        //head is the first element in the queue
        private int _head;
        //tail is the place where the element to be added
        private int _tail;
        //count is the number of elements in the queue
        private int _count;
        //Size of the array
        private int _capacity;
        //Array to store elements
        private Type[] _array;
        //Public number of elements
        public int Count { get { return _count; } }
        public CustomQueue()
        {
            //By default _capacity is 4
            _capacity = 4;
            //By intial count,head,tail = 0
            _count = 0;
            _head = 0;
            _tail = 0;
            //_array with size 4
            _array = new Type[_capacity];
        }

        public CustomQueue(int size)
        {
            //By User defined _capacity size
            _capacity = size;
            //By intial count,head,tail = 0
            _count = 0;
            _head = 0;
            _tail = 0;
            //_array with user defined size 
            _array = new Type[_capacity];
        }

        public void Enqueue(Type value)
        {
            //Add an element to queue
            if (_tail == _capacity)
            {
                //If capacity limit is reached Grow Size
                GrowSize();
            }
            _array[_tail] = value;
            _count++;
            _tail++;
        }
        public Type Peek()
        {
            //To view the first element in the queue
            if(_head==_tail)
            {
                return default(Type);
            }
            else
            {
                //return the first element
                return _array[_head];
            }
        }

        public Type Dequeue()
        {
            //To check queue is empty
            if(_head==_tail)
            {
                return default(Type);
            }
            else
            {
                //If not empty move the head place
                //Decrease _count Here no need to change array
                _head++;
                _count--;
                //return the removed queue element
                return _array[_head-1];
            }
        }

        void GrowSize()
        {
            _capacity = _capacity * 2;
            //Increasing the capacity
            //temp array with increased capacity size
            Type[] temp = new Type[_capacity];
            for (int i = _head; i < _tail; i++)
            {
                //Coppying from array to temp
                temp[i] = _array[i];
            }
            //Changing reference of temp to array
            _array = temp;
        }
          int position;
        //For Each Looping
        public IEnumerator GetEnumerator()
        {
            position = _head-1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (position < _tail - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = _head-1;
        }

        public object Current { get { return _array[position]; } }
    }
}