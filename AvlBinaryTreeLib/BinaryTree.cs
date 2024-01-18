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
            if(root.Right == null)
            {
                root.Right = new Node<T>(value);
            }
            else
            {
                root.Right.Insert(value);
            }

            return this;
        }

        public Node<T>? Search(T value)
        {
            return root.Right?.Search(value);
        }

        private Node<T> root = new Node<T>(default);

        public int? BalanceFactor => root.Right?.BalanceFactor();
    }
}