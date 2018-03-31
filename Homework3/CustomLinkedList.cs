using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Homework 3
/// Class Description   : Custom Linked List class
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : March 31, 2018
/// Filename            : CustomLinkedList.cs
/// </summary>

namespace Homework3
{
    class CustomLinkedList
    {
        private CustomNode head;
        private CustomNode tail;

        private int count;

        public CustomNode Head
        {
            get { return this.head; }
            set { this.head = value; }
        }

        public CustomNode Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        /// <summary>
        /// Add a new node to the linked list
        /// </summary>
        /// <param name="data">Data to add as a new node</param>
        public void Add(string data)
        {
            if (Head == null)
            {
                Head = new CustomNode(data);
                Tail = Head;

                Count++;
            }
            else
            {
                Tail.Next = new CustomNode(data);
                Tail.Next.Previous = Tail;
                Tail = Tail.Next;

                Count++;
            }
        }

        /// <summary>
        /// Insert an entry at the index provided
        /// </summary>
        /// <param name="data">Data to insert</param>
        /// <param name="index">Index at which to insert</param>
        public void Insert(string data, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("\n*** The index provided is out of bounds, please enter an index >= 0 and < " + Count + " ***\n");
            }
            else if (index >= Count)
            {
                this.Add(data);
            }
            else
            {
                CustomNode current = Head;

                for (int i = 0; i < (index - 1); i++)
                {
                    current = current.Next;
                }

                current.Next.Previous = new CustomNode(data);
                current.Next.Previous.Previous = current;
                current.Next.Previous.Next = current.Next;
                current.Next = current.Next.Previous;

                Count++;
            }
        }

        /// <summary>
        /// Remove a node and it's data from the list at the specified index
        /// </summary>
        /// <param name="index">Index of node that needs to be removed from the list</param>
        /// <returns></returns>
        public string Remove(int index)
        {
            string returnValue = null;

            CustomNode current = Head;

            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException("\n*** The index provided is out of bounds, please enter an index >= 0 and < " + Count + " ***\n");
            }
            else if ((index == 0) && (Count > 1))
            {
                returnValue = Head.Data;

                Head = Head.Next;
            }
            else if (index == (Count - 1))
            {
                for (int i = 0; i < (index - 1); i++)
                {
                    current = current.Next;
                }

                returnValue = current.Next.Data;

                Tail = current;
                current.Next = null;
            }
            else
            {
                for (int i = 0; i < (index - 1); i++)
                {
                    current = current.Next;
                }

                returnValue = current.Next.Data;

                current.Next = current.Next.Next;
            }

            Count--;

            return returnValue;
        }

        /// <summary>
        /// Print the data contained in the node at the specified index
        /// </summary>
        /// <param name="index">The index of the data requested</param>
        /// <returns></returns>
        public string GetData(int index)
        {
            string returnValue = null;

            CustomNode current = Head;

            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException("\n*** The index provided is out of bounds, please enter an index >= 0 and < " + Count + " ***\n");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                returnValue = current.Data;
            }

            return returnValue;
        }

        /// <summary>
        /// Print the contents of the list in reverse order
        /// </summary>
        public void PrintReversed()
        {
            CustomNode current = Tail;

            for (int i = Count; i > 0; i--)
            {                
                Console.WriteLine("Index " + (i - 1) + " : " + current.Data);

                current = current.Previous;
            }
        }

        /// <summary>
        /// Clear the contents of the list
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Tail = head;
            this.Count = 0;
        }
    }
}
