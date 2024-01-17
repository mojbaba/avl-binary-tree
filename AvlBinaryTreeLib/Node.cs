using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            Value = value;
            Height = 0;
        }

        public int Height { get; private set; }
        public T Value { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        private Node<T> Parent { get; set; }

        public void Insert(T ivalue)
        {
            var comparedTo = ivalue.CompareTo(Value);

            if (comparedTo > 0)
            {
                InsertRight(ivalue);
            }
            else if (comparedTo < 0)
            {
                InsertLeft(ivalue);
            }

            this.Height = Math.Max(Left?.Height ?? 0, Right?.Height ?? 0) + 1;
        }

        private void InsertRight(T ivalue)
        {
            if (Right is not null)
            {
                Right.Insert(ivalue);
            }
            else
            {
                Right = new Node<T>(ivalue)
                {
                    Parent = this
                };
            }
        }

        private void InsertLeft(T ivalue)
        {
            if (Left is not null)
            {
                Left.Insert(ivalue);
            }
            else
            {
                Left = new Node<T>(ivalue)
                {
                    Parent = this
                };
            }
        }


    }
}