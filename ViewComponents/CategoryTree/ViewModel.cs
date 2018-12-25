using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Itminus.CategoryTree
{
    public class CategoryTreeViewModel<TCategory>
        where TCategory : Category
    {

        /// <summary>
        /// Trees
        /// </summary>
        public IList<TreeNode<TCategory>> Trees { get; set; }

        /// <summary>
        /// Convert : TCategory -> Href
        /// </summary>
        public Func<TCategory, string> ConvertCategoryToHref { get; set; } = c => c.Id.ToString();

        /// <summary>
        /// css class name for active node (e.g. when hover)
        /// </summary>
        public string ActiveCssClass { get; set; }
    }
}
