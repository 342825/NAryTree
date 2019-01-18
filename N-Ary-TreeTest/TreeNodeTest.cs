using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using N_Ary_Tree;

namespace N_Ary_TreeTest
{
    [TestFixture]
    public class TreeNodeTest
    {
        [TestCase]
        public void TestTreeAddChild()
        {
            //Arrange
            Tree<int> TreeInt = new Tree<int>();
            Tree<string> TreeStr = new Tree<string>();

            //Act
            //int
            var root = TreeInt.AddChildNode(null,1);
            var child1 = TreeInt.AddChildNode(root, 2);
            var child2 = TreeInt.AddChildNode(root, 3);
            //str
            var rootstr = TreeStr.AddChildNode(null, "A");
            var child1str = TreeStr.AddChildNode(rootstr, "B");
            var child2str = TreeStr.AddChildNode(rootstr, "C");

            //Assert
           
            Assert.Multiple(() =>
            {
                // controle lengte
                Assert.That(TreeInt.count == 3);
                Assert.That(TreeStr.count == 3);
                // check aantal leafs
                Assert.That(TreeInt.leafcount == 2);
                Assert.That(TreeStr.leafcount == 2);
                // Controle input
                Assert.Contains(root, TreeInt.TheTree);
                Assert.Contains(rootstr, TreeStr.TheTree);
                // controle kinderen
                Assert.Contains(child1, root.Child);
                Assert.Contains(child2, root.Child);
                Assert.Contains(child1str, rootstr.Child);
                Assert.Contains(child2str, rootstr.Child);

            });
        }

        [TestCase]
        public void TestTreeRemoveNode()
        {
            //Arrange
            Tree<int> TreeInt = new Tree<int>();
            Tree<string> TreeStr = new Tree<string>();

            //Act
            //int
            var root = TreeInt.AddChildNode(null, 1);
            var child1 = TreeInt.AddChildNode(root, 2);
            var child2 = TreeInt.AddChildNode(root, 3);
            var child11 = TreeInt.AddChildNode(child1, 4);
            TreeInt.removeNode(child1);
            //str
            var rootstr = TreeStr.AddChildNode(null, "A");
            var child1str = TreeStr.AddChildNode(rootstr, "B");
            var child2str = TreeStr.AddChildNode(rootstr, "C");
            var child11str = TreeStr.AddChildNode(child1str, "D");
            TreeStr.removeNode(child1str);
            //Assert

            Assert.Multiple(() =>
            {
                // controle lengte
                Assert.That(TreeInt.count == 2);
                Assert.That(TreeStr.count == 2);
                // check aantal leafs
                Assert.That(TreeInt.leafcount == 1);
                Assert.That(TreeStr.leafcount == 1);
                // controle of alle kinderen zijn verwijderd
                for (int i = 0; i < TreeInt.count; i++)
                {
                    Assert.AreNotSame(child11, TreeStr.TheTree[i]);
                    Assert.AreNotSame(child1, TreeInt.TheTree[i]);
                }
                for (int i = 0; i < TreeStr.count; i++)
                {
                    Assert.AreNotSame(child11, TreeStr.TheTree[i]);
                    Assert.AreNotSame(child1str, TreeStr.TheTree[i]);
                }
            });
        }
        [TestCase]
        public void TestTreeSumOfLeaves()
        {
            //Arrange
            Tree<int> TreeInt = new Tree<int>();
            Tree<string> TreeStr = new Tree<string>();

            //Act
            //int
            var root = TreeInt.AddChildNode(null, 1);
            var child1 = TreeInt.AddChildNode(root, 2);
            var child2 = TreeInt.AddChildNode(root, 3);
            var child11 = TreeInt.AddChildNode(child1, 4);
            var sumleafs = TreeInt.SumToLeafs();
            //str
            var rootstr = TreeStr.AddChildNode(null, "A");
            var child1str = TreeStr.AddChildNode(rootstr, "B");
            var child2str = TreeStr.AddChildNode(rootstr, "C");
            var child11str = TreeStr.AddChildNode(child1str, "D");
            var sumleafsstr = TreeStr.SumToLeafs();

            //Assert

            Assert.Multiple(() =>
            {
                // controle of sumofleaves goed worden opgeteld
                Assert.That(sumleafs[1] == 7);
                Assert.That(sumleafsstr[0] == "CA");
            });
            }
    }
}
