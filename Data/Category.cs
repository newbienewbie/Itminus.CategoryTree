using System.ComponentModel.DataAnnotations.Schema;

namespace Itminus.CategoryTree{

    /// <summary>
    /// 分类基类，其余定制的类应继承自该类
    /// Category为了存储方便，只以外键形式记录父级分类，不便于检索子类，
    ///     为了方便检索子类，还需要用TreeNode构建
    /// base class for Category
    /// </summary>
    public class Category{

        /// <summary>
        /// 分类号
        /// </summary>
        public int Id{get;set;}

        /// <summary>
        /// 当前分类所属的作用域
        /// </summary>
        public string Scope {get;set;}

        /// <summary>
        /// 分类名
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Pid
        /// </summary>
        public int? Pid {get;set;}

        /// <summary>
        /// 备注
        /// </summary>
        public string Note {get;set;}

        [ForeignKey("Pid")]
        public Category Parent{get;set;}
    }
}