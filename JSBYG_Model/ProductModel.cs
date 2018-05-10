using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSBYG_Model
{
    public  class ProductModel
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string pName { get; set; }
        
        /// <summary>
        /// 产品说明
        /// </summary>
        public string pRecommend { get; set; }

        /// <summary>
        /// 产品单位价格
        /// </summary>
        public decimal pUnitPrice { get; set; }

        /// <summary>
        /// 产品总数量
        /// </summary>
        public int pTotalCount { get; set; }

        /// <summary>
        /// 产品单位
        /// </summary>
        public string pUnit { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string pImage { get; set; }
    }
}
