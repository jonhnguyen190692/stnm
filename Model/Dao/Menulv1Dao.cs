using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class Menulv1Dao
    {
        DBModel db = null;

        public Menulv1Dao()
        {
            db = new DBModel();
        }

        public int Insert(MenuLevel1 entity)
        {
            db.MenuLevel1.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.IDMenuLevel1;
        }

        public MenuLevel1 GetMenuById(int id)
        {
            return db.MenuLevel1.FirstOrDefault(x => x.IDMenuLevel1 == id);
        }

        public bool UpdateMenu(MenuLevel1 entity)
        {
            try
            {
                var model = db.MenuLevel1.Find(entity.IDMenuLevel1);
                model.Name = entity.Name;
                model.Status = entity.Status;
                model.Position = entity.Position;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MenuLevel1> ListAllPaging(int page, int pageSize)
        {
            return db.MenuLevel1.OrderBy(x => x.Position).ToPagedList(page,pageSize);
        }

        public bool Delete (int id)
        {
            try
            {
                var model = db.MenuLevel1.Find(id);
                db.MenuLevel1.Remove(model);
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
