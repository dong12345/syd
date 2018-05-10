using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JSBYG_BLL;
using JSBYG_Model;
using JSBYG.Areas.Product.Models;

namespace JSBYG.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        ProductBLL bll = new ProductBLL();
        // GET: Product/Product
        public ActionResult Index(int? id)
        {
            return View("GetList");
        }

        #region 获取产品列表
        [HttpGet]
        public ActionResult GetList(int page=1,int pageSize=10)
        {
            List<ProductModel> list = bll.GetListByPage(string.Empty, string.Empty, pageSize, page);
            int count = bll.GetRecordCount(string.Empty);
            List<ProductVM> vmList = ProductDataHelper.ModelListToVM(list);
            return Json(new { data = vmList, total=count,msg="", status = 200 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取产品详情
        [HttpGet]
        public ActionResult GetDetial(int id=0)
        {
            ProductVM vm = null;
            if (id != 0)
            {
                ProductModel model = bll.GetModel(Convert.ToInt32(id));
                vm = ProductDataHelper.ModelToVM(model);
            }
            if (vm == null)
            {
                return View("ErrorPage");
            }
            return View(vm);
        }

        #endregion

        #region 获取产品详情(js缓存方式)
        //[HttpGet]
        //public ActionResult GetDetial(ProductVM vm)
        //{
           
        //    return View(vm);
        //}
        #endregion
        [HttpPost]
        public ActionResult Edit(ProductVM vm)
        {
            if (vm != null)
            {
                ProductModel model = ProductDataHelper.VMToModel(vm);
                
                if (bll.Updtate(model))
                {
                    return Json(new { message = "更新成功" });
                }
                else
                {
                    return Json(new { message = "更新失败" });
                }
            }
            else {
                return Json(new { message = "请检查要更新的数据" });
            }
            
           
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
     
    }
}