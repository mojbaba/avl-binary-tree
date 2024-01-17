using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class Node<T>(T value) where T : IComparable<T>
    {
        enum Added
        {
            Left,
            Right,
            None
        }

        public int Height { get; private set; } = 1;
        public T Value { get; } = value;
        public Node<T>? Left { get; private set; }
        public Node<T>? Right { get; private set; }

        private Node<T>? Parent { get; set; }

        public void Insert(T ivalue)
        {
            Add(ivalue);
        }

        private Added Add(T ivalue)
        {
            var comparedTo = ivalue.CompareTo(Value);
            Added firstAdded = Added.None;
            Added secondAdded = Added.None;

            if (comparedTo > 0)
            {
                firstAdded = Added.Right;
                secondAdded = InsertRight(ivalue);
            }
            else if (comparedTo < 0)
            {
                firstAdded = Added.Left;
                secondAdded = InsertLeft(ivalue);
            }

            if (BalanceFactor() > 1)
            {
                Rebalance(firstAdded, secondAdded);
            }

            this.Height = Math.Max(Left?.Height ?? 0, Right?.Height ?? 0) + 1;

            return firstAdded;
        }

        private void Rebalance(Added first, Added second)
        {
            Action? action = (first, second) switch
            {
                (Added.Right, Added.Right) => RR,
                (Added.Left, Added.Left) => LL,
                (Added.Right, Added.Left) => RL,
                (Added.Left, Added.Right) => LR,
                _ => null
            };

            action?.Invoke();
        }

        private void RR()
        {
            var A = this;
            var B = A.Right;
            var C = B?.Right;

            ChangeChild(A, B);

            var L_B = B.Left;

            SetRight(A, L_B);

            SetLeft(B, A);
        }

        private void LL()
        {
            var A = this;
            var B = A.Left;
            var C = B.Left;

            ChangeChild(A, B);

            var R_B = B.Right;

            SetLeft(A, R_B);

            SetRight(B, A);
        }
        private void RL()
        {
            var A = this;
            var B = A.Right;
            var C = B.Left;

            ChangeChild(A, C);

            var L_C = C.Left;
            var R_C = C.Right;

            SetRight(A, L_C);

            SetLeft(B, R_C);

            SetLeft(C, A);

            SetRight(C, B);
        }
        private void LR()
        {
            var A = this;
            var B = A.Left;
            var C = B?.Right;

            ChangeChild(A, C);

            var L_C = C.Left;

            var R_C = C.Right;

            SetLeft(A, R_C);

            SetRight(B, L_C);

            SetRight(C, A);

            SetLeft(C, B);
        }

        private static void ChangeChild(Node<T> oldChild, Node<T>? newChild)
        {
            if (oldChild.Parent is null)
                return;

            if (oldChild.Parent.Left == oldChild)
                oldChild.Parent.Left = newChild;
            else
                oldChild.Parent.Right = newChild;
        }

        private static void SetLeft(Node<T> parent, Node<T>? child)
        {
            parent.Left = child;

            if (child is not null)
                child.Parent = parent;
        }

        private static void SetRight(Node<T> parent, Node<T>? child)
        {
            parent.Right = child;

            if (child is not null)
                child.Parent = parent;
        }

        public int BalanceFactor()
        {
            var leftHeight = Left?.Height ?? 0;
            var rightHeight = Right?.Height ?? 0;
            return Math.Abs(leftHeight - rightHeight);
        }

        private Added InsertRight(T ivalue)
        {
            if (Right is not null)
            {
                return Right.Add(ivalue);
            }
            else
            {
                Right = new Node<T>(ivalue)
                {
                    Parent = this
                };

                return Added.None;
            }
        }

        private Added InsertLeft(T ivalue)
        {
            if (Left is not null)
            {
                return Left.Add(ivalue);
            }
            else
            {
                Left = new Node<T>(ivalue)
                {
                    Parent = this
                };

                return Added.None;
            }
        }

        internal Node<T>? Search(T value)
        {
            Node<T>? node =  value.CompareTo(Value) switch
            {
                0 => this,
                -1 => this.Left?.Search(value),
                1 => this.Right?.Search(value),
                _ => null
            };

            return node;
        }
    }
}