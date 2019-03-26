using Model.EF;
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
    }
}
