using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree<T> Insert(T value)
        {
            root.Insert(value);

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
    }
}