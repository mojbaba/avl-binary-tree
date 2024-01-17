using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvlBinaryTreeLib;
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
            Assert.Equal(0, tree.BalanceFactor);
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
            Assert.Equal(0, tree.BalanceFactor);
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
            Assert.Equal(0, tree.BalanceFactor);
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
            Assert.Equal(0, tree.BalanceFactor);
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