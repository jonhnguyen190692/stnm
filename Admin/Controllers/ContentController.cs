using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int page =1,int pageSize =1)
        {
            var model = new ContentDao().GetAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            SetViewBag();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Content entity)
        {
            if (ModelState.IsValid)
            {
                long id;
                entity.Status = true;
                entity.CreatedOn = DateTime.Now;
                try
                {
                    id = new ContentDao().Insert(entity);
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Content", "Index"));
                }
                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                    return RedirectToAction("Index", "Content");
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
                SetViewBag();
                return View();
            }
           
        }


        [HttpGet]
        public ActionResult Update(long id)
        {
            var model = new ContentDao().GetByID(id);
            GetDropdown(long.Parse(model.ID.ToString()));
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            bool result = new ContentDao().Delete(id);
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
            ViewBag.CategoryID = new SelectList(new CategoryDao().ListCategory(), "ID", "Name", selectedId);
        }

        public JsonResult SaveImages(long id, string images)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var imageList = js.Deserialize<List<string>>(images);
            XElement x = new XElement("Images");

            foreach (var item in imageList)
            {
                var newItem = item.Substring(22);
                x.Add(new XElement("Image", newItem));
            }
            ContentDao dao = new ContentDao();
            try
            {

                dao.UpdateImage(id, x.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }


        }

        public JsonResult LoadImage(long id)
        {
            var model = new ContentDao().GetByID(id);
            var images = model.MoreImages;
            XElement xImages = XElement.Parse(images);
            List<string> listImages = new List<string>();

            foreach (XElement item in xImages.Elements())
            {
                listImages.Add(item.Value);
            }
            return Json(new
            {
                data = listImages
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContentDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public ActionResult GetDropdown(long id)
        {
            DBModel db = new DBModel();
            List<SelectListItem> l = new List<SelectListItem>();
            var model = db.Categories.Where(x => x.Status == true).OrderByDescending(x => x.ID == id).ToArray();
            for (int i = 0; i < model.Length; i++)
            {
                l.Add(new SelectListItem { Value = model[i].ID.ToString(), Text = model[i].Name });
            }
            ViewData["danhsach"] = l;
            return View();

        }
    }
}