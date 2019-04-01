using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new CategoryDao().ListAllPagging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category entity)
        {
            if (ModelState.IsValid)
            {
                long id;
                try
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.Status = true;
                    id = new CategoryDao().Insert(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Category", "Create"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                    return RedirectToAction("Create");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var model = new CategoryDao().GetByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Category entity)
        {
            bool result;
            try
            {
                result = new CategoryDao().Update(entity);
            }
            catch (Exception ex)
            {
                return View("Eror", new HandleErrorInfo(ex, "Category", "Index"));
            }
            if (result)
            {
                ModelState.AddModelError("","Cập nhật thành công");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool result = new CategoryDao().Delete(id);
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

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }


    }
}