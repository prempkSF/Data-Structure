using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueDS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Queue<string>myQueue=new Queue<string>();
            myQueue.Enqueue("one");
            myQueue.Enqueue("two");
            myQueue.Enqueue("three");
            Queue<string> queue1=myQueue;
           int len=myQueue.Count;
            // for(int i=0;i<len;i++)
            // {
            //     System.Console.WriteLine(queue1.Peek());
            //     queue1.Dequeue();
            // }

            CustomQueue<int> myCustomQueue=new CustomQueue<int>(4);
            myCustomQueue.Enqueue(1);
            myCustomQueue.Enqueue(2);
            myCustomQueue.Enqueue(3);
            myCustomQueue.Enqueue(4);
            myCustomQueue.Enqueue(5);
            myCustomQueue.Enqueue(6);
            System.Console.WriteLine("Before 2 Dequeue");
            foreach(int queue in myCustomQueue)
            {
                System.Console.WriteLine(queue);
            }
            myCustomQueue.Dequeue();
            myCustomQueue.Dequeue();
            System.Console.WriteLine("After 2 Dequeue");
            foreach(int queue in myCustomQueue)
            {
                System.Console.WriteLine(queue);
            }
        }
    }
}