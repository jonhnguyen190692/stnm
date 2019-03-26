using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var model = new ProductCategoryDao().ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                long id;
                try
                {
                    //entity.CreatedBy = "";
                    entity.CreatedOn = DateTime.Now;
                    id = dao.Insert(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "ProductCategory", "Create"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            bool result = new ProductCategoryDao().Delete(id);
            if (result)
            {
                ModelState.AddModelError("", "Xóa thành công");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var entity = new ProductCategoryDao().GetByID(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(ProductCategory entity)
        {
            bool result;
            if (ModelState.IsValid)
            {
                try
                {
                    result = new ProductCategoryDao().Update(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "ProductCategory", "Update"));
                }
                if (result)
                {
                    ModelState.AddModelError("","Cập nhật thành công");
                   return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                    return RedirectToAction("Update");
                }
            }
            return View();
        }
    }
}