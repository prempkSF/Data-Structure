using System;
using System.Collections;

namespace StackDS
{
    class Program 
    {
        public static void Main(string[] args)
        {
            // Stack newStack=new Stack();
            // newStack.Push(4);
            // newStack.Push(5);
            // newStack.Push(6);
            // newStack.Pop();
            
            // System.Console.WriteLine(newStack.Pop());
            // System.Console.WriteLine(newStack.Pop());
            //Created Custom Stack
            CustomStack<int> customStack=new CustomStack<int>(4);
            customStack.Push(4);
            customStack.Push(5);
            customStack.Push(6);
            customStack.Push(7);
            customStack.Push(8);
            customStack.Push(9);
            System.Console.WriteLine(customStack.Pop());
            System.Console.WriteLine(customStack.Peek());
            System.Console.WriteLine(customStack.Contains(4));
            customStack.Clear();
            System.Console.WriteLine(customStack.Pop());
        }
    }
}