using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        DBModel db = null;

        public ProductDao()
        {
            db = new DBModel();
        }

        public long Create(Product entity)
        {
            try
            {
                entity.CreatedOn = DateTime.Now;
                db.Products.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.ID;
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize)
        {
            return db.Products.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public Product GetByID(long id)
        {
            return db.Products.FirstOrDefault(x=>x.ID == id);
        }

        public bool Update(Product entity)
        {
            try
            {
                var model = db.Products.Find(entity.ID);
                model.Image = entity.Image;
                model.CategoryID = entity.CategoryID;
                model.Code = entity.Code;
                model.Description = entity.Description;
                model.Detail = entity.Detail;
                model.IncludeVAT = entity.IncludeVAT;
                model.MetaDescriptions = entity.MetaDescriptions;
                model.MetaKeywords = entity.MetaKeywords;
                model.MetaTitle = entity.MetaTitle;
                //model.ModifiedBy = "";
                model.ModifiedOn = DateTime.Now;
                model.MoreImages = entity.MoreImages;
                model.Name = entity.Name;
                model.Price = entity.Price;
                model.PromotionPrice = entity.PromotionPrice;
                model.Quantity = entity.Quantity;
                model.Status = entity.Status;
                model.TopHot = entity.TopHot;
                model.ViewCount = entity.ViewCount;
                model.Waranty = entity.Waranty;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateImage(long id, string images)
        {
            var model = db.Products.Find(id);
            model.MoreImages = images;
            db.SaveChanges();
        }

        public bool Delete(long id)
        {
            try
            {
                var model = db.Products.FirstOrDefault(x => x.ID == id);
                db.Products.Remove(model);
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
            var model = db.Products.Find(id);
            model.Status = !model.Status;
            db.SaveChanges();
            return bool.Parse(model.Status.ToString());
        }
    }
}
