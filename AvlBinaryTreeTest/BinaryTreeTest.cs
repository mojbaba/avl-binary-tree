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
        public void Test1()
        {
            var tree = new AvlBinaryTreeLib.BinaryTree<int>();

            var values = new int[] {40,20,10,25,30,22,50};

            foreach (var item in values)
            {
                tree.Insert(item);
            }
        }
    }
}