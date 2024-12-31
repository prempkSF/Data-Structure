

namespace StackDS
{
    public class CustomStack<Type>
    {
        //No For Each and Index fo Stack
        //Cannot access inbetween values

        //top the value position
        private int _top;
        //Capacity of the array
        private int _capacity;
        //array
        private Type[] _array;
        //Public Capacity
        public int Capacity {get{return _capacity;}}
        //Public Count
        public int Count {get{return _top+1;}}

        public CustomStack()
        {
            //Initial top -1 capacity 4
            _top=-1;
            _capacity=4;
            _array=new Type[_capacity];
        }


        public CustomStack(int size)
        {
            //Initial top -1 capacity User Defined Size
            _top=-1;
            _capacity=size;
            _array=new Type[_capacity];
        }

        //To Push in the stack at top+1 Position
        // On top of stack
        public void Push(Type value)
        {
            if(_capacity==_top+1)
            {
                //If top == capacity Grow Size
                GrowSize();
            }
            //Add element to the array
            _array[_top+1]=value;
            //Increase top position
            _top++;
        }
        public Type Peek()
        {
            if(_top==-1)
            {
                //If stack is empty
                //Return Default value
                return default(Type);
            }
            else{
                //Retrun the top position
                return _array[_top];
            }
        }

        public Type Pop()
        {
            if(_top==-1)
            {
                //If stack is empty
                //Return Default value
                return default(Type);
            }
            else
            {
                //Pop the top position element
                //Ignore array top position once popped
                _top=_top-1;
                return _array[_top+1];
            }
        }

        //To find an element exist or not
        public bool Contains(Type value)
        {
            int position=-1;
            //Traverse the array 
            for(int i=0;i<_top+1;i++)
            {
                if(value.Equals(_array[i]))
                {
                    //If element found
                    //True
                    position=i;
                    break;
                }
            }
            if(position>-1)
            {
                //Not Found
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Clear()
        {
            //Making the Stack Empty 
            _capacity=4;
            //Intial capacity
            Type[] temp = new Type[_capacity];
            //top to -1
            _top=-1;
            _array=temp;
        }
        void GrowSize()
        {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            //Creating an temp array with 2x the capacity
            for(int i=0;i<_top+1;i++)
            {
                //Copying the element
                temp[i]=_array[i];
            }
            //Copying the reference of temp to _array
            _array=temp;
        }
    }
}