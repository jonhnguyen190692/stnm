using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class AboutDao
    {
       private DBModel db = null;

        public AboutDao()
        {
            db = new DBModel();
        }

        public long Insert (About entity)
        {
            try
            {
                db.Abouts.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.ID;
        }

        public IEnumerable<About> ListAllPagging(int page,int pageSize)
        {
            return db.Abouts.OrderBy(x => x.CreatedOn).ToPagedList(page, pageSize);
        }

        public bool ChangeStatus(long id)
        {
                var model = db.Abouts.Find(id);
                model.Status = !model.Status;
                db.SaveChanges();
                return bool.Parse(model.Status.ToString());
            
        }

        public bool Delete(long id)
        {
            try
            {
                var model = db.Abouts.FirstOrDefault(x => x.ID == id);
                db.Abouts.Remove(model);
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
