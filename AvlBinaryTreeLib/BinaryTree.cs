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
            if(root == null)
            {
                root = new Node<T>(value);
            }
            else
            {
                root.Insert(value);
            }

            return this;
        }

        public Node<T>? Search(T value)
        {
            return root?.Search(value);
        }

        private Node<T>? root;

        public int? BalanceFactor => root?.BalanceFactor();
    }
}