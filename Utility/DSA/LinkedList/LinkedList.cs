using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int data)
        {
            this.val = data;
            this.next = null;
        }
    }

    public class LinkedList
    {
        public ListNode head;

        public void AddNode(int value, int index)
        {
            int size = Length();
            if (index == size)
                AddAtLast(value);
            else if (index > size || index < 0)
                return;
            else if (index == 0)
                AddAtFirst(value);
            else
                AddAt(value, index);
        }

        public void AddAtLast(int data)
        {
            ListNode newNode = new ListNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            ListNode currNode = head;
            while(currNode.next != null)
            {
                currNode = currNode.next;
            }
            currNode.next = newNode;
        }

        public void AddAtFirst(int data)
        {
            ListNode newNode = new ListNode(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            newNode.next = head;
            head = newNode;
        }

        public void AddAt(int data, int position)
        {
            if (head == null)
                return;
            else if (position == 0)
            {
                ListNode headNode = new ListNode(data);
                headNode.next = head;
                head = headNode;
                return;
            }
            int posCnt = 0;
            ListNode currNode = head;
            int len = Length();
            while (currNode.next != null && position <= len)
            {
                posCnt++;
                if (position == posCnt) break;
                currNode = currNode.next;
            }
            ListNode newNode = new ListNode(data);
            newNode.next = currNode.next;
            currNode.next = newNode;
        }

        public void DeleteAt(int position)
        {
            if (head == null) return;
            else if (position == 0)
            {
                head = head.next;
                return;
            }
            int posCnt = 0;
            ListNode currNode = head;
            while(currNode.next != null)
            {
                posCnt++;
                if (posCnt == position) break;
                currNode = currNode.next;
            }
            currNode.next = currNode.next.next;
        }

        public void DeleteByValue(int data, int position)
        {
            if (head == null) return;
            ListNode currNode = head;
            int size = Length();
            if (position < size)
            {
                if (position == 0)
                {
                    head = head.next;
                }
                else
                {
                    for (int k = 0; k < position - 1; k++)
                    {
                        currNode = currNode.next;
                    }
                    currNode.next = currNode.next.next;
                }
                size -= 1;
            }
        }

        public void DeleteLast()
        {
            if (head == null) return;
            if (head.next == null)
            {
                head = null;
                return;
            }
            ListNode currNode = head;
            while (currNode.next.next != null)
                currNode = currNode.next;
            currNode.next = null;
        }

        public int Length()
        {
            if (head == null) return 0;
            ListNode currNode = head;
            int cnt = 1;
            while (currNode.next != null)
            {
                cnt++;
                currNode = currNode.next;
            }
            return cnt;
        }

        public void PrintAllNodes()
        {
            if (head == null) return;
            ListNode currNode = head;
            Console.Write(currNode.val);
            currNode = currNode.next;
            while(currNode != null)
            {
                Console.Write(" " + currNode.val);
                currNode = currNode.next;
            }
        }
    }
}
