using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public BinaryTree<T> Add(T value)
        {
            root.Add(value);

            return this;
        }

        public Node<T>? Search(T value)
        {
            return root.Right?.Search(value);
        }

        private Node<T> root = new Node<T>(default)
        {
            IsDummy = true
        };

        public int? BalanceFactor() => root.Right?.BalanceFactor();

        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeEnumerator<T>(root.Right);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}