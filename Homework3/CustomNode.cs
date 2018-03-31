using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// IGME-106 - Game Development and Algorithmic Problem Solving
/// Homework 3
/// Class Description   : Custom Node class
/// Author              : Benjamin Kleynhans
/// Modified By         : Benjamin Kleynhans
/// Date                : March 31, 2018
/// Filename            : CustomNode.cs
/// </summary>

namespace Homework3
{
    class CustomNode
    {
        private string data;
        private CustomNode next;
        private CustomNode previous;

        public CustomNode(string inputData)
        {
            this.Data = inputData;
            this.Next = null;
            this.Previous = null;
        }

        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        
        public CustomNode Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public CustomNode Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}
