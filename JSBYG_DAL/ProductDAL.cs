using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JSBYG_IDAL;
using JSBYG_Model;
using JSBYG_Common;
using System.Reflection;

namespace JSBYG_DAL
{
    public class ProductDAL : IBasicOperate<ProductModel>
    {
        public bool Delete(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from T_Product where Id=@Id ");
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int) { Value=id}
            };
            return SqlHelper.ExecuteNonquery(sb.ToString(), sp) > 0;

        }

        public List<ProductModel> GetAllList()
        {
            List<ProductModel> list = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, pName, pRecommend, pUnitPrice, pTotalCount, pUnit, pImage ");
            sb.Append(" from T_Product");

            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());
            if (dt.Rows.Count > 0)
            {
                list = DataHelper.GetList<ProductModel>(dt);
            }
            return list;

        }

        public List<ProductModel> GetListByPage(string strWhere, string orderBy, int pageSize, int page)
        {
            List<ProductModel> list = null;
            int startIndex = page < 1 ? 1 : ((page - 1) * pageSize) + 1;
            int endIndex = page < 1 ? pageSize : page * pageSize;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ( ");
            sb.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                sb.Append("order by T." + orderBy);
            }
            else
            {
                sb.Append("order by T.Id desc");
            }
            sb.Append(")AS Row, T.*  from T_Product T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sb.Append(" WHERE " + strWhere);
            }
            sb.Append(" ) TT");
            sb.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString());
            if (dt.Rows.Count > 0)
            {
                list = DataHelper.GetList<ProductModel>(dt);
            }
            return list;
        }

        public ProductModel GetModel(int id)
        {
            ProductModel model = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select Id, pName, pRecommend, pUnitPrice, pTotalCount, pUnit, pImage ");
            sb.Append(" from T_Product where Id=@Id");
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Id",SqlDbType.Int) { Value=id}
            };
            DataTable dt = SqlHelper.ExecuteDataTable(sb.ToString(), sp);
            if (dt.Rows.Count > 0)
            {
                model = DataHelper.GetModel<ProductModel>(dt);
            }
            return model;
        }


        public int GetRecordCount(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) FROM T_Product ");
            if (strWhere.Trim() != "")
            {
                sb.Append(" where " + strWhere);
            }
            object obj = SqlHelper.ExecuteScalar(sb.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        public bool Insert(ProductModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@" insert into T_Product values( 
                                pName=@pName, 
                                pRecommend=@pRecommend,
                                pUnitPrice=@pUnitPrice, 
                                pTotalCount=@pTotalCount,
                                pUnit=@pUnit,
                                pImage=@pImage) ");
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@pName",SqlDbType.NVarChar) { Value=model.pName},
                new SqlParameter("@pRecommend",SqlDbType.NVarChar) { Value=model.pRecommend},
                new SqlParameter("@pUnitPrice",SqlDbType.Decimal) { Value=model.pUnitPrice},
                new SqlParameter("@pTotalCount",SqlDbType.Int) { Value=model.pTotalCount},
                new SqlParameter("@pUnit",SqlDbType.NVarChar) { Value=model.pUnit},
                new SqlParameter("@pImage",SqlDbType.NVarChar) { Value=model.pImage}
            };
            return SqlHelper.ExecuteNonquery(sb.ToString(), sp) > 0;
        }

        public bool Updtate(ProductModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@" update T_Product set 
                                pName=@pName, 
                                pRecommend=@pRecommend,
                                pUnitPrice=@pUnitPrice, 
                                pTotalCount=@pTotalCount,
                                pUnit=@pUnit,
                                pImage=@pImage 
                                where Id=@Id ");
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@pName",SqlDbType.NVarChar) { Value=model.pName},
                new SqlParameter("@pRecommend",SqlDbType.NVarChar) { Value=model.pRecommend},
                new SqlParameter("@pUnitPrice",SqlDbType.Decimal) { Value=model.pUnitPrice},
                new SqlParameter("@pTotalCount",SqlDbType.Int) { Value=model.pTotalCount},
                new SqlParameter("@pUnit",SqlDbType.NVarChar) { Value=model.pUnit},
                new SqlParameter("@pImage",SqlDbType.NVarChar) { Value=model.pImage},
                new SqlParameter("@Id",SqlDbType.Int) { Value=model.Id}
            };
            return SqlHelper.ExecuteNonquery(sb.ToString(), sp) > 0;
        }
    }
}
