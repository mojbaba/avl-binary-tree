using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AvlBinaryTreeLib
{
    public class Node<T>(T value) where T : IComparable<T>
    {
        enum Added
        {
            Left,
            Right
        }

        public bool IsDummy { get; set; }

        public int Height { get; private set; } = 1;
        public T Value { get; } = value;
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        internal void Add(T ivalue)
        {
            Insert(ivalue);
        }

        private Stack<Added> InsertRight(T ivalue)
        {
            Stack<Added> stack;

            if (Right is not null)
            {
                stack = Right.Insert(ivalue);
            }
            else
            {
                Right = new Node<T>(ivalue);
                stack = new Stack<Added>();
            }

            stack.Push(Added.Right);

            return stack;
        }

        private Stack<Added> InsertLeft(T ivalue)
        {
            Stack<Added> stack;

            if (Left is not null)
            {
                stack = Left.Insert(ivalue);
            }
            else
            {
                Left = new Node<T>(ivalue);
                stack = new Stack<Added>();
            }

            stack.Push(Added.Left);

            return stack;
        }

        private Stack<Added> Insert(T ivalue)
        {
            var comparedTo = ivalue.CompareTo(Value);
            Stack<Added> stack;

            if (IsDummy || comparedTo > 0)
            {
                stack = InsertRight(ivalue);

                if (Right.BalanceFactor() > 1)
                    Rebalance(Right, stack);
            }
            else if (comparedTo < 0)
            {
                stack = InsertLeft(ivalue);

                if (Left.BalanceFactor() > 1)
                    Rebalance(Left, stack);
            }
            else
            {
                stack = new Stack<Added>();
            }

            CalculateHeight(this);

            return stack;
        }

        private void Rebalance(Node<T> balancingRoot, Stack<Added> stack)
        {
            var current = stack.Pop();

            var first = stack.Pop();
            var second = stack.Pop();

            stack.Push(current);

            Rebalance(balancingRoot, first, second);
        }

        private void Rebalance(Node<T> balancingRoot, Added first, Added second)
        {
            Action<Node<T>>? action = (first, second) switch
            {
                (Added.Right, Added.Right) => RightRightRotation,
                (Added.Left, Added.Left) => LeftLeftRotation,
                (Added.Right, Added.Left) => RightLeftRotation,
                (Added.Left, Added.Right) => LeftRightRotation,
                _ => null
            };

            action?.Invoke(balancingRoot);
        }

        private void ChangeMyChild(Node<T> oldChild, Node<T> newChild)
        {
            if (Left == oldChild)
            {
                Left = newChild;
            }
            else
            {
                Right = newChild;
            }
        }

        private static void CalculateHeight(Node<T> node)
        {
            node.Height = Math.Max(node.Left?.Height ?? 0, node.Right?.Height ?? 0) + 1;
        }

        private void RightRightRotation(Node<T> balancingRoot)
        {
            var A = balancingRoot;
            var B = A.Right;
            var C = B.Right;

            var L_B = B.Left;

            A.Right = L_B;
            B.Left = A;

            ChangeMyChild(A, B);

            CalculateHeight(A);
            CalculateHeight(B);
            CalculateHeight(this);
        }

        private void LeftLeftRotation(Node<T> balancingRoot)
        {
            var A = balancingRoot;
            var B = A.Left;
            var C = B.Left;

            var R_B = B.Right;

            A.Left = R_B;
            B.Right = A;

            ChangeMyChild(A, B);

            CalculateHeight(A);
            CalculateHeight(B);
            CalculateHeight(this);
        }

        private void RightLeftRotation(Node<T> balancingRoot)
        {
            var A = balancingRoot;
            var B = A.Right;
            var C = B.Left;

            var L_C = C.Left;
            var R_C = C.Right;

            A.Right = L_C;
            B.Left = R_C;

            C.Left = A;
            C.Right = B;

            ChangeMyChild(A, C);

            CalculateHeight(A);
            CalculateHeight(B);
            CalculateHeight(C);
            CalculateHeight(this);
        }

        private void LeftRightRotation(Node<T> balancingRoot)
        {
            var A = balancingRoot;
            var B = A.Left;
            var C = B.Right;

            var L_C = C.Left;
            var R_C = C.Right;

            B.Right = L_C;
            A.Left = R_C;

            C.Left = B;
            C.Right = A;

            ChangeMyChild(A, C);

            CalculateHeight(A);
            CalculateHeight(B);
            CalculateHeight(C);
            CalculateHeight(this);
        }

        public int BalanceFactor()
        {
            var leftHeight = Left?.Height ?? 0;
            var rightHeight = Right?.Height ?? 0;
            return Math.Abs(leftHeight - rightHeight);
        }

        internal Node<T>? Search(T value)
        {
            if (IsDummy)
                return Right?.Search(value);

            Node<T>? node = value.CompareTo(Value) switch
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