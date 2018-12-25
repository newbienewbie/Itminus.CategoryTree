using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Itminus.CategoryTree
{
    /// <summary>
    /// 从`TCategory`中读取Value和Children，
    /// </summary>
    /// <typeparam name="TCategory"></typeparam>
    public class TreeNode<TCategory>
        where TCategory :Category
    {
        public TCategory Value { get; set; }
        public List<TreeNode<TCategory>> Children { get; set; }

        public TreeNode(TCategory tree)
        {
            this.Value = tree;
            this.Children = new List<TreeNode<TCategory>>();
        }
    }

}
