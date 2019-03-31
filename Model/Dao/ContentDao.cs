using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
  public  class ContentDao
    {
        private DBModel db = null;

        public ContentDao()
        {
            db = new DBModel();
        }

        public long Insert(Content entity)
        {
            try
            {
                db.Contents.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.ID;
        }

        public IEnumerable<Content> GetAllPaging(int page, int pageSize)
        {
            return db.Contents.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public Content GetByID(long id)
        {
            return db.Contents.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateImage(long id, string images)
        {
            var model = db.Contents.Find(id);
            model.MoreImages = images;
            db.SaveChanges();
        }
    }
}
