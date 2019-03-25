using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Admin.Controllers
{
    public class MenuLevel2Controller : Controller
    {
        // GET: MenuLevel1
        public ActionResult Index(int page=1, int pageSize= 10)
        {
            DBModel db = new DBModel();
            var model = new Menulv2Dao().ListAllPaging(page, pageSize);
            var related = db.MenuLevel1.ToList(); 
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuLevel2 entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new Menulv2Dao();
                int id;
                //id = dao.Insert(entity);
                try
                {
                    id = dao.Insert(entity);
                }
                catch (Exception ex)
                {

                    return View("Error", new HandleErrorInfo(ex, "MenuLevel2", "Create"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm thành công");
                    return RedirectToAction("Index","MenuLevel2");
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
            var entity = new Menulv2Dao().GetMenuById(id);
            SetViewBag(entity.IDMenuLevel1);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(MenuLevel2 entity, int id)
        {
            bool result;
            if (ModelState.IsValid)
            {
                Menulv2Dao dao = new Menulv2Dao();
                entity.IDMenuLevel2 = id;
                try
                {
                    result = dao.UpdateMenu(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "MenuLevel2", "Update"));
                }
                if (result)
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thành công");
                    return RedirectToAction("Index", "MenuLevel2");
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
            new Menulv2Dao().Delete(id);
            return RedirectToAction("Index");
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDMenuLevel1 = new SelectList(dao.ListMenuLV1(), "IDMenuLevel1", "Name", selectedID);
        }
    }
}