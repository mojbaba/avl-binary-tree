using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class BinaryTreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private Node<T> _root;
        private Node<T> _current = null;
        private Stack<Node<T>> _parents = new Stack<Node<T>>();

        public BinaryTreeEnumerator(Node<T> root)
        {
            _root = root;
        }


        private Node<T> FindLeftMost(Node<T> node)
        {
            if (node.Left is null)
            {
                return node;
            }
            else
            {
                _parents.Push(node);
                return FindLeftMost(node.Left);
            }
        }

        public T Current
        {
            get
            {
                return _current.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current is null)
            {
                _current = FindLeftMost(_root);
                return true;
            }
            
            if (_current.Right is not null)
            {
                _current = FindLeftMost(_current.Right);
                return true;
            }

            if (_parents.Count == 0)
            {
                return false;
            }
            else
            {
                _current = _parents.Pop();
                return true;
            }

        }

        public void Reset()
        {
            _current = FindLeftMost(_root);
        }
    }
}