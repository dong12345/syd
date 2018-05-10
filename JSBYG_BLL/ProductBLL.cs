using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSBYG_DAL;
using JSBYG_Model;

namespace JSBYG_BLL
{
    public class ProductBLL
    {
        ProductDAL dal = new ProductDAL();
        public ProductModel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public List<ProductModel> GetAllList()
        {
            return dal.GetAllList();
        }

        public List<ProductModel> GetListByPage(string strWhere, string orderBy, int pageSize, int page)
        {
            return dal.GetListByPage(strWhere,orderBy,pageSize,page);
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public bool Updtate(ProductModel model)
        {
            return dal.Updtate(model);
        }
    }
}
