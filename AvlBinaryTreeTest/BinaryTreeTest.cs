using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvlBinaryTreeLib;
using NuGet.Frameworks;
using Xunit;

namespace AvlBinaryTreeTest
{
    public class BinaryTreeTest
    {

        [Fact]
        public void SimpleRRTest()
        {
            // Given
            var tree = new BinaryTree<int>();

            // When
            tree.Insert(10)
                .Insert(20)
                .Insert(30);


            // Then
            Assert.Equal(0, tree.BalanceFactor());
            var A = tree.Search(10);
            var B = tree.Search(20);
            var C = tree.Search(30);

            Assert.True(B.Left == A);
            Assert.True(B.Right == C);

            Assert.True(A.Left == null);
            Assert.True(A.Right == null);

            Assert.True(C.Left == null);
            Assert.True(C.Right == null);
        }


        [Fact]
        public void SimpleLLTest()
        {
            // Given
            var tree = new BinaryTree<int>();

            // When
            tree.Insert(30)
                .Insert(20)
                .Insert(10);


            // Then
            Assert.Equal(0, tree.BalanceFactor());
            var A = tree.Search(30);
            var B = tree.Search(20);
            var C = tree.Search(10);

            Assert.True(B.Left == C);
            Assert.True(B.Right == A);

            Assert.True(A.Left == null);
            Assert.True(A.Right == null);

            Assert.True(C.Left == null);
            Assert.True(C.Right == null);
        }

        [Fact]
        public void SimpleRLTest()
        {
            // Given
            var tree = new BinaryTree<int>();

            // When
            tree.Insert(10)
                .Insert(30)
                .Insert(20);


            // Then
            Assert.Equal(0, tree.BalanceFactor());
            var A = tree.Search(10);
            var B = tree.Search(30);
            var C = tree.Search(20);

            Assert.True(C.Left == A);
            Assert.True(C.Right == B);

            Assert.True(A.Left == null);
            Assert.True(A.Right == null);

            Assert.True(B.Left == null);
            Assert.True(B.Right == null);
        }

        [Fact]
        public void SimpleLRTest()
        {
            // Given
            var tree = new BinaryTree<int>();

            // When
            tree.Insert(30)
                .Insert(10)
                .Insert(20);


            // Then
            Assert.Equal(0, tree.BalanceFactor());
            var A = tree.Search(30);
            var B = tree.Search(10);
            var C = tree.Search(20);

            Assert.True(C.Left == B);
            Assert.True(C.Right == A);

            Assert.True(A.Left == null);
            Assert.True(A.Right == null);

            Assert.True(B.Left == null);
            Assert.True(B.Right == null);
        }

        [Fact]
        public void Test1()
        {
            var tree = new AvlBinaryTreeLib.BinaryTree<int>();

            var values = new int[] { 40, 20, 10, 25, 30, 22, 50 };

            foreach (var item in values)
            {
                tree.Insert(item);
            }
        }
    }
}