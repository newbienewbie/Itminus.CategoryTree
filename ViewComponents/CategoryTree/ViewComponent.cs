using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itminus.CategoryTree
{

    public abstract class CategoryTreeViewComponent<TCategory> : ViewComponent
        where TCategory: Category
    {
        /// <summary>
        /// invoke ViewComponent
        /// </summary>
        /// <param name="trees">it will automaticly retrieve from database with initialPredicate if null </param>
        /// <param name="ConvertCategoryToHref">a func to convert id to href</param>
        /// <param name="activeCssClass">css class when active</param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(
            IList<TreeNode<TCategory>> Trees , 
            Func<TCategory,string> ConvertCategoryToHref , 
            TCategory Current,
            string ActiveCssClass="" 
        )
        {
            return View(new CategoryTreeViewModel<TCategory> {
                Trees = Trees,
                ConvertCategoryToHref= ConvertCategoryToHref,
                ActiveCssClass = ActiveCssClass,
            });
        }

    }

    /// <summary>
    /// default tree component 
    /// </summary>
    public class CategoryTreeViewComponent : CategoryTreeViewComponent<Category>
    {
        // empty
    }


}
