using JSBYG_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBYG.Areas.Product.Models
{
    public static class ProductDataHelper
    {
        public static ProductVM ModelToVM(ProductModel model)
        {
            ProductVM vm = new ProductVM();
            vm.Id = model.Id;
            vm.Image = model.pImage;
            vm.Name = model.pName;
            vm.Recommend = model.pRecommend;
            vm.TotalCount = model.pTotalCount;
            vm.Unit = model.pUnit;
            vm.UnitPrice = model.pUnitPrice;
            return vm;
        }

        public static List<ProductVM> ModelListToVM(List<ProductModel> modelList)
        {
            List<ProductVM> vmList = new List<ProductVM>();
            for (int i = 0; i < modelList.Count; i++)
            {
                ProductVM vm = new ProductVM();
                ProductModel model = modelList[i];
                vm = ModelToVM(model);
                vmList.Add(vm);
            }
            return vmList;
        }

        public static ProductModel VMToModel(ProductVM vm)
        {
            ProductModel model = new ProductModel();
            model.Id = vm.Id;
            model.pImage = vm.Image;
            model.pName = vm.Name;
            model.pRecommend = vm.Recommend;
            model.pTotalCount = vm.TotalCount;
            model.pUnit = vm.Unit;
            model.pUnitPrice = vm.UnitPrice;
            return model;
        }
    }
}