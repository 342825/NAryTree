using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Ary_Tree
{

    public class Tree<T>
    {
        public int count { get; set; }
        public int leafcount{get; set;}
        public Tree()
        {
            count = 0;
            leafcount = 0;
        }
        public List<TreeNode<T>> TheTree = new List<TreeNode<T>>();
        TreeNode<T> rootNode;

        public TreeNode<T> AddChildNode(TreeNode<T> parentNode, T Value)
        {
            TreeNode<T> newNode = new TreeNode<T>(Value, parentNode, new List<TreeNode<T>>());
            if (parentNode != null)
            {
                TheTree.Add(newNode);
                parentNode.Child.Add(newNode);

            }
            else
            {
                rootNode = newNode;
                TheTree.Add(rootNode);
            }
            Leafcount();
            count++;

            return newNode;
        }
        public int Leafcount()
        {
            leafcount = 0;
            foreach (TreeNode<T> leaf in TheTree)
            {
                if (leaf.Child.Count == 0)
                {
                    leafcount++;
                }
            }
            return leafcount;
        }
        public void removeNode(TreeNode<T> node)
        {
            this.TheTree.Remove(node); // node uit tree halen
            var parentNode = node.Parent; // uit node zijn parent halen
            parentNode.Child.Remove(node); // haal node uit de parent
            count--;
            if (node.Child.Count == 0)
            { }
            else
            {
                for (int i = node.Child.Count - 1; i >= 0; i--)
                {
                    removeNode(node.Child[i]);
                }
            }
            Leafcount();
        }
        public List<T> TraverseNodes()
        {
            List<T> traversednodes = new List<T>();
            foreach (TreeNode<T> node in TheTree)
                traversednodes.Add(node.Value);
            return traversednodes;
        }
        public List<T> SumToLeafs()
        {

            List<T> AllSom = new List<T>();
            List<TreeNode<T>> AllLeafs = new List<TreeNode<T>>();
            foreach (TreeNode<T> leaf in TheTree)
            {
                if (leaf.Child.Count == 0)
                {
                    AllLeafs.Add(leaf);
                }
            }
            foreach (TreeNode<T> leafs in AllLeafs)
            {

                TreeNode<T> Parent = leafs;
                //dynamic Som = 0;
                List<dynamic> Som = new List<dynamic>();
                Som.Add(Parent.Value);
                while (Parent.Parent != null)
                {
                    Som[0] = Som[0] + Parent.Parent.Value;
                    Parent = Parent.Parent;
                }
                AllSom.Add(Som[0]);
            }
            return AllSom;
        }
    }
}