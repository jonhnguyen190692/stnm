using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
   public class FooterDao
    {
       private DBModel db = null;

        public FooterDao()
        {
            db = new DBModel();
        }

        public long Insert(Footer entity)
        {
            try
            {
                db.Footers.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           return entity.ID;

        }

        public bool Delete(int id)
        {
            try
            {
                var model = db.Footers.Find(id);
                db.Footers.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Footer GetByID(int id)
        {
            return db.Footers.FirstOrDefault(x => x.ID == id);
        }

        public bool Update(Footer entity)
        {
            try
            {
                var model = db.Footers.Find(entity.ID);
                model.Content = entity.Content;
                model.ModifiedOn = DateTime.Now;
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
