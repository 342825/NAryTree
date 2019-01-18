using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Ary_Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public TreeNode<T> Parent { get; set; }

        public List<TreeNode<T>> Child { get; set; }

        public TreeNode(T value, TreeNode<T> parent, List<TreeNode<T>> child)
        {
            Value = value;
            Parent = parent;
            Child = child;
        }

    }
}