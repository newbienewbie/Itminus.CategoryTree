using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Itminus.CategoryTree
{
    public static class CategoryExtension
    {
        public static IQueryable<TCategory> ListWithinScope<TCategory>(this IQueryable<TCategory> Categories, string scope)
            where TCategory : Category
        {
            return Categories.Where(c => c.Scope == scope);
        }

        public static async Task<List<TreeNode<TCategory>>> TreeList<TCategory>(this IQueryable<TCategory> categories, Expression<Func<TCategory, bool>> predicate )
            where TCategory : Category
        {
            var cList = predicate == null?
                await categories.ToListAsync() :
                await categories.Where(predicate).ToListAsync();
            return ListToTrees(cList, null);
        }

        public static async Task<IList<int>> GetCatorySubNodeIdList<TCategory>(this IQueryable<TCategory> categories, int pid, Expression<Func<TCategory, bool>> predicate)
            where TCategory : Category
        {
            var clist = await categories.Where(predicate).ToListAsync();
            return SubNodeIdList(clist, pid);
        }

        /// <summary>
        /// 递归地把数组中以pid为祖先的节点转换为层级式的树形结构。
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pid">如果pid==null，则自顶而下全部转换</param>
        /// <returns></returns>
        public static List<TreeNode<TCategory>> ListToTrees<TCategory>(IList<TCategory> list, int? pid)
            where TCategory : Category
        {
            var trees = list.Where(c => c.Pid == pid)
                    .Select(c => new TreeNode<TCategory>(c))
                    .ToList();
            foreach (var c in trees)
            {
                int? id = c.Value?.Id;
                c.Children = ListToTrees<TCategory>(list, id);
            }
            return trees;
        }

        /// <summary>
        /// 获取数组之中的某个节点的所有子孙的id(返回的结果不包含指定的父节点)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<int> SubNodeIdList<TCategory>(IList<TCategory> list, int? id)
            where TCategory : Category
        {
            // 以id为父节点的节点
            var sublist = list.Where(s => s.Pid == id).ToList();
            // 获取直属子节点的id列表
            var ids = sublist.Select(s => s.Id).ToList();
            foreach (var i in sublist)
            {
                var subids = SubNodeIdList(list, i.Id);
                ids = ids.Concat(subids).ToList();
            }
            return ids;
        }


        //public static IQueryable<Category> TreeWithinScope(this IQueryable<Category> Categories , string scope ) {
        //}

    }
}
