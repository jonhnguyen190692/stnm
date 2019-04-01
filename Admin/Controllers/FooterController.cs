using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Footer entity)
        {
            if (ModelState.IsValid)
            {
                long id;
                
                try
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.Status = true;
                    id = new FooterDao().Insert(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Footer", "Index"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return RedirectToAction("Index");
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
            bool result = new FooterDao().Delete(id);
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
            var model = new FooterDao().GetByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update (Footer entity)
        {
            bool result;
            try
            {
                result = new FooterDao().Update(entity);
            }
            catch (Exception ex)
            {
                return View("Eror", new HandleErrorInfo(ex, "Category", "Index"));
            }
            if (result)
            {
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
                return RedirectToAction("Index");
            }
        }
    }
}