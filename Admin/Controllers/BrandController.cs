using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index(int page = 1, int pageSize = 30)
        {
            var model = new BrandDao().ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand entity)
        {
            if (ModelState.IsValid)
            {
                long id;
                try
                {
                    entity.Status = true;
                    entity.CreatedOn = DateTime.Now;
                    id = new BrandDao().Insert(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Brand", "Index"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return RedirectToAction("Create");
                }
            }
            else
            {
                SetViewBag();
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return RedirectToAction("Create");
            }
        }

        [HttpGet]
        public ActionResult Update(long id)
        {

            var model = new BrandDao().GetByID(id);
            GetDropdown(long.Parse(model.ParentID.ToString()));
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Brand entity)
        {
            if (ModelState.IsValid)
            {
                bool result;
                try
                {
                    result = new BrandDao().Update(entity);
                }
                catch (Exception ex)
                {
                    return View("Eror", new HandleErrorInfo(ex, "Brand", "Index"));
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
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View();
            }

        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool result = new BrandDao().Delete(id);
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

        public void SetViewBag(long? selectedId = null)
        {
            ViewBag.ParentID = new SelectList(new ProductCategoryDao().ListProductCtegory(), "ID", "Name", selectedId);
        }

        public ActionResult GetDropdown(long id)
        {
            DBModel db = new DBModel();
            List<SelectListItem> l = new List<SelectListItem>();
            var model = db.ProductCategories.Where(x => x.Status == true && x.LevelMenu == 1).OrderByDescending(x => x.ParentID == id).ToArray();
            for (int i = 0; i < model.Length; i++)
            {
                l.Add(new SelectListItem { Value = model[i].ID.ToString(), Text = model[i].Name });
            }
            ViewData["danhsach"] = l;
            return View();

        }
    }
}