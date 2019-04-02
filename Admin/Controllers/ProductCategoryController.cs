using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index(string searchString ,int page = 1, int pageSize = 30)
        {
            var model = new ProductCategoryDao().ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            //LoadCategory(0);
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
                    entity.Status = true;
                    entity.ShowOnhome = false;
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
            GetDropdown(long.Parse(entity.ParentID.ToString()));
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
                    ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                    return RedirectToAction("Update");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin");
                return View();
            }
        }

        public void SetViewBag(long? selectedId = null)
        {
            ViewBag.CategoryID = new SelectList(new ProductCategoryDao().ListProductCtegory(), "ID", "Name", selectedId);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductCategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public JsonResult GetCountries()
        {
            var Countries = new List<ListItem>();
            Countries.Add(new ListItem("Cấp menu", "0"));
            Countries.Add(new ListItem("Cấp 1", "1"));
            Countries.Add(new ListItem("Cấp 2", "2"));
            Countries.Add(new ListItem("Cấp 3", "3"));
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetStates(string id)
        {
            ListItem item = new ListItem();
            int newID = int.Parse(id);
            var States = new ProductCategoryDao().LoadCategory(newID);

            return Json(States, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult AjaxMethod()
        //{
        //    DBModel db = new DBModel();
        //    List<SelectListItem> customers = new List<SelectListItem>();
        //    var entities = db.ProductCategories.Where(x=>x.Status == true).ToArray();
        //    for (int i = 0; i < entities.Length; i++)
        //    {
        //        customers.Add(new SelectListItem
        //        {
        //            Value = entities[i].ID.ToString(),
        //            Text = entities[i].Name
        //        });
        //    }

        //    return Json(customers);
        //}

        public ActionResult GetDropdown(long id)
        {
            DBModel db = new DBModel();
            List<SelectListItem> l = new List<SelectListItem>();
            var model = db.ProductCategories.Where(x => x.Status == true).OrderByDescending(x => x.ParentID == id).ToArray();
            for (int i = 0; i < model.Length; i++)
            {
                l.Add(new SelectListItem { Value = model[i].ID.ToString(), Text = model[i].Name });
            }
            ViewData["danhsach"] = l;
            return View();

        }
    }
}