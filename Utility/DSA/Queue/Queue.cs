using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.Queue
{
    public class Queue
    {
        int[] queueArr;
        int front;
        int rear;
        public Queue(int queueSize)
        {
            front = -1;
            rear = -1;
            queueArr = new int[queueSize];
        }

        public void Push(int data)
        {
            if (rear - front > queueArr.Length - 1) return;
            queueArr[++rear] = data;
            if (front == -1) front++;
        }

        public void Pop()
        {
            if (front == -1 || rear == -1) return;
            else
            {
                front++;
            }
        }

        public int Peek()
        {
            if (front == -1 || rear == -1) return -1;
            else
            {
                return queueArr[front];
            }
        }

        public void Print()
        {
            if (front == -1 || rear == -1) return;
            else
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.Write(queueArr[i] + " ");
                }
            }
        }
    }
}
