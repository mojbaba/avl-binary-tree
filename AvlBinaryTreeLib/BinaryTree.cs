using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int _version = 0;
        public BinaryTree<T> Add(T value)
        {
            root.Add(value);
            _version++;
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
            return new BinaryTreeEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct BinaryTreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private BinaryTree<T> _binaryTree;
            private int _version;
            private Node<T> _current = null;
            private Stack<Node<T>> _parents = new Stack<Node<T>>();

            public BinaryTreeEnumerator(BinaryTree<T> binaryTree)
            {
                _binaryTree = binaryTree;
                _version = binaryTree._version;
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
                if(_version != _binaryTree._version)
                {
                    throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
                }
                if (_current is null)
                {
                    _current = FindLeftMost(_binaryTree.root.Right);
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
                _current = FindLeftMost(_binaryTree.root.Right);
            }
        }
    }
}