using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Admin.Controllers
{
    public class MenuLevel1Controller : Controller
    {
        // GET: MenuLevel1
        public ActionResult Index(int page=1, int pageSize= 10)
        {
            var model = new Menulv1Dao().ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuLevel1 entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new Menulv1Dao();
                int id;
                //id = dao.Insert(entity);
                try
                {
                    id = dao.Insert(entity);
                }
                catch (Exception ex)
                {

                    return View("Error", new HandleErrorInfo(ex, "MenuLevel1", "Create"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index","MenuLevel1");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return View("Create");
                }
            }
           else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View("Create");
            }
        }

        public ActionResult Update(int id)
        {
            var entity = new Menulv1Dao().GetMenuById(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(MenuLevel1 entity, int id)
        {
            bool result;
            if (ModelState.IsValid)
            {
                Menulv1Dao dao = new Menulv1Dao();
                entity.IDMenuLevel1 = id;
                try
                {
                    result = dao.UpdateMenu(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "MenuLevel1", "Update"));
                }
                if (result)
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thành công");
                    return RedirectToAction("Index", "MenuLevel1");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin không thành công");
                    return View("Update");
                }
            }
            return View("Update");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new Menulv1Dao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}