using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AvlBinaryTreeTest
{
    public class IterationTest
    {
        [Fact]
        public void SimpleIterationTest()
        {
            var tree = new AvlBinaryTreeLib.BinaryTree<int>();

            var values = new int[] { 40, 20, 10, 25, 30, 22, 50 };

            foreach (var item in values)
            {
                tree.Add(item);
            }

            var sorted = tree.ToList();

            Assert.Equal(7, sorted.Count);
            Assert.Equal(10, sorted[0]);
            Assert.Equal(20, sorted[1]);
            Assert.Equal(22, sorted[2]);
            Assert.Equal(25, sorted[3]);
            Assert.Equal(30, sorted[4]);
            Assert.Equal(40, sorted[5]);
            Assert.Equal(50, sorted[6]);            
        }
    }
}