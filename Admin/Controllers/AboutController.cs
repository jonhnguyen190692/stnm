using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index(int page =1,int pageSize =1)
        {
            var model = new AboutDao().ListAllPagging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create (About entity)
        {
            if (ModelState.IsValid)
            {
                long id;

                try
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.Status = true;
                    id = new AboutDao().Insert(entity);
                }
                catch (Exception ex)
                {

                    return View("Error", new HandleErrorInfo(ex, "About", "Index"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return View();
                }
                
            }
            else
            {
                ModelState.AddModelError("","Vui lòng nhập đầy đủ thông tin");
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool result = new AboutDao().Delete(id);
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
            var result = new AboutDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}