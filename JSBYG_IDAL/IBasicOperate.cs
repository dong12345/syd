using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSBYG_IDAL
{
    /// <summary>
    /// 基本操作
    /// </summary>
    public interface IBasicOperate<T>
    { 
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">泛型实例</param>
        /// <returns></returns>
        bool Insert(T model);

        /// <summary>
        /// 根据Id删除数据
        /// </summary>
        /// <param name="id">要删除数据的主键Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 根据Id更新数据
        /// </summary>
        /// <param name="model">泛型实例</param>
        /// <returns></returns>
        bool Updtate(T model);

        /// <summary>
        /// 根据Id得到泛型对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetModel(int id);

        /// <summary>
        /// 根据条件得到数据总数
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        int GetRecordCount(string strWhere);

        /// <summary>
        /// 得到所有泛型集合
        /// </summary>
        /// <returns></returns>
        List<T> GetAllList();

        /// <summary>
        /// 得到泛型分页集合
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageSize">每页显示数据条数</param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        List<T> GetListByPage(string strWhere, string orderBy, int pageSize, int page);

    }
}
