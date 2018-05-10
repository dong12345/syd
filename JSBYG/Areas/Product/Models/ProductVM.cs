using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBYG.Areas.Product.Models
{
    public class ProductVM
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品说明
        /// </summary>
        public string Recommend { get; set; }

        /// <summary>
        /// 产品单位价格
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 产品总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 产品单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string Image { get; set; }
    }
}