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
    public class BrandDao
    {
        DBModel db = null;

        public BrandDao()
        {
            db = new DBModel();
        }

        public long Insert(Brand entity)
        {
            db.Brands.Add(entity);
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

        public IEnumerable<Brand> ListAllPaging(int page, int pageSize)
        {
            return db.Brands.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Delete(long id)
        {
            try
            {
                var model = db.Brands.Find(id);
                db.Brands.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Brand GetByID(long id)
        {
            return db.Brands.FirstOrDefault(x => x.ID == id);
        }

        public bool Update(Brand entity)
        {
            try
            {
                var model = db.Brands.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = entity.MetaTitle;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaDescriptions = entity.MetaDescriptions;
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
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<ProductCategory> ListCategoryParent()
        {
            return db.ProductCategories.Where(x => x.Status == true);
        }

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
