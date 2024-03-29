using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvlBinaryTreeLib;
using NuGet.Frameworks;
using Xunit;

namespace AvlBinaryTreeTest
{
    public class BalancingTest
    {

        [Fact]
        public void SimpleRRTest()
        {
            // Given
            var tree = new BinaryTree<int>();

            // When
            tree.Add(10)
                .Add(20)
                .Add(30);


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
            tree.Add(30)
                .Add(20)
                .Add(10);


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
            tree.Add(10)
                .Add(30)
                .Add(20);


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
            tree.Add(30)
                .Add(10)
                .Add(20);


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
        public void ExampleTest1()
        {
            var tree = new AvlBinaryTreeLib.BinaryTree<int>();

            var values = new int[] { 40, 20, 10, 25, 30, 22, 50 };

            foreach (var item in values)
            {
                tree.Add(item);
            }

            Assert.Equal(0, tree.BalanceFactor());

            /* should be like this

            25--------40---50
            |         |
            20--22    30
            |
            10

            */


            var root = tree.Search(25);
            Assert.True(root.Left.Value == 20);
            Assert.True(root.Left.Left.Value == 10);
            Assert.True(root.Left.Right.Value == 22);
            Assert.True(root.Right.Value == 40);
            Assert.True(root.Right.Left.Value == 30);
            Assert.True(root.Right.Right.Value == 50);
        }

        [Fact]
        public void ExampleTest2()
        {
            // Given
            var tree = new AvlBinaryTreeLib.BinaryTree<int>();

            var values = new int[] { 40, 30, 50, 20, 45, 35, 60, 41, 46, 70 };

            foreach (var item in values)
            {
                tree.Add(item);
            }

            
            Assert.Equal(1, tree.BalanceFactor());

            tree.Add(42);

            Assert.Equal(0, tree.BalanceFactor());
            
        }
    }
}