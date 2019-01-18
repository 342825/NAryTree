using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Ary_Tree
{
    class Program
    {
        static void Main()
        {

            var NAryTree = new Tree<int>();
            var root = new TreeNode<int>(1, null, new List<TreeNode<int>>());

            var child1 = NAryTree.AddChildNode(root, 3);
            var child11 = NAryTree.AddChildNode(root, 4);
            var child12 = NAryTree.AddChildNode(root, 5);
            var child2 = NAryTree.AddChildNode(child1, 6);
            //NAryTree.removeNode(child1);
            //var TheTree = NAryTree.TraverseNodes();
            var TheTree = NAryTree.SumToLeafs();
            for (int i=0; i<TheTree.Count; i++)
            {
                Console.WriteLine(TheTree[i]);
            }



            Console.WriteLine(NAryTree.leafcount);
            //Console.WriteLine(TheTree.Capacity);
            Console.ReadLine();



        }
    }
}