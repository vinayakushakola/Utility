using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.Stack
{
    public class Stack
    {
        int[] stackArr;
        int top = -1;
        public Stack(int stackSize) 
        {
            stackArr = new int[stackSize];
        }

        public void push(int data)
        {
            if (top == stackArr.Length - 1) return;
            stackArr[++top] = data;
        }

        public void pop()
        {
            if (top == -1) return;
            else top--;
        }

        public int peek()
        {
            if (top == -1) return -1;
            return stackArr[top];
        }

        public int size()
        {
            return top+1;
        }

        public bool isEmpty()
        {
            if (top == -1) return true;
            else return false;
        }

        public void print()
        {
            for (int i = 0; i <= top; i++)
                Console.Write(stackArr[i] +" ");
        }
    }
}
