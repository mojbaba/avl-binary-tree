using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public bool IsAvl { get; set; }
        public void Insert(T value)
        {
            if(root == null)
            {
                root = new Node<T>(value);
            }
            else
            {
                root.Insert(value);
            }
        }

        public void Search(T value)
        {
            throw new NotImplementedException();
        }

        private Node<T> root;
    }
}