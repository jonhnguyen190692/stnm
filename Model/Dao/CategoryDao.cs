using Model.EF;
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
                entity.CreatedOn = DateTime.Now;
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

    }
}
