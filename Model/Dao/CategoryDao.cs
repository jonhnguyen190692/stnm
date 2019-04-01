using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class CategoryDao
    {
        private DBModel db = null;

        public CategoryDao()
        {
            db = new DBModel();
        }

        public long Insert(Category entity)
        {
            try
            {
                //entity.CreatedOn = DateTime.Now;
                db.Categories.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.ID;
           
        }

        public Category GetByID(long id)
        {
            return db.Categories.FirstOrDefault(x=>x.ID == id);
        }

        public IEnumerable<Category> ListAllPagging(int page, int pageSize)
        {
            return db.Categories.OrderBy(x => x.DisplayOrder).ToPagedList(page, pageSize);
        }

        public bool Delete(long id)
        {
            try
            {
                var model = db.Categories.FirstOrDefault(x => x.ID == id);
                db.Categories.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var model = db.Categories.Find(id);
            model.Status = !model.Status;
            db.SaveChanges();
            return bool.Parse(model.Status.ToString());
        }

        public IEnumerable<Category> ListCategory()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        public bool Update(Category entity)
        {
            try
            {
                var model = db.Categories.Find(entity.ID);
                model.DisplayOrder = entity.DisplayOrder;
                model.Image = entity.Image;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                model.ModifiedOn = DateTime.Now;
                model.Name = entity.Name;
                model.SeoTitle = entity.SeoTitle;
                model.ShowOnhome = entity.ShowOnhome;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
