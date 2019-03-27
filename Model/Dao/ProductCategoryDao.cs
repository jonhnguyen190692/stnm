using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<ProductCategory> ListAllPaging(int page,int pageSize)
        {
            return db.ProductCategories.OrderBy(x => x.CreatedOn).ToPagedList(page, pageSize);
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

        public bool Update (ProductCategory entity)
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
                model.ParentID = model.ParentID;
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
    }
}
