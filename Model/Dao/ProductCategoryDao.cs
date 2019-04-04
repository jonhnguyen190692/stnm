using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        DBModel db = null;

        public ProductCategoryDao()
        {
            db = new DBModel();
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.ID;
        }

        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.DisplayOrder).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var model = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductCategory GetByID(int id)
        {
            return db.ProductCategories.FirstOrDefault(x => x.ID == id);
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var model = db.ProductCategories.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = entity.MetaTitle;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.LevelMenu = entity.LevelMenu;
                model.Image = entity.Image;
                //model.ModifiedBy = "";
                model.ModifiedOn = DateTime.Now;
                model.ParentID = entity.ParentID;
                model.SeoTitle = entity.SeoTitle;
                model.ShowOnhome = entity.ShowOnhome;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ProductCategory> ListProductCtegory()
        {
            var model = db.ProductCategories.Where(x => x.Status == true && x.LevelMenu ==1).OrderBy(x=>new { x.LevelMenu,x.DisplayOrder}).ToList();
            return model;
        }

        //public IEnumerable<ProductCategory> ListCategoryParent()
        //{
        //    return db.ProductCategories.Where(x => x.Status == true).ToList();
        //}

        public bool ChangeStatus(long id)
        {
            var model = db.ProductCategories.Find(id);
            model.Status = !model.Status;
            db.SaveChanges();
            return bool.Parse(model.Status.ToString());
        }

        public IEnumerable<ProductCategory> LoadCategory(int id)
        {
            var items = db.ProductCategories.Where(x => x.LevelMenu == (id - 1)).ToList();
            return items;
        }

    }
}
