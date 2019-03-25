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
    public class Menulv2Dao
    {
        DBModel db = null;

        public Menulv2Dao()
        {
            db = new DBModel();
        }

        public int Insert(MenuLevel2 entity)
        {
            db.MenuLevel2.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.IDMenuLevel2;
        }

        public MenuLevel2 GetMenuById(int id)
        {
            return db.MenuLevel2.FirstOrDefault(x => x.IDMenuLevel2 == id);
        }

        public bool UpdateMenu(MenuLevel2 entity)
        {
            try
            {
                var model = db.MenuLevel2.Find(entity.IDMenuLevel2);
                model.Name = entity.Name;
                model.Status = entity.Status;
                model.Position = entity.Position;
                model.IDMenuLevel1 = entity.IDMenuLevel1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<MenuLevel2> ListAllPaging(int page, int pageSize)
        {
            return db.MenuLevel2.OrderBy(x => x.Position).ToPagedList(page,pageSize);
        }

        public bool Delete (int id)
        {
            try
            {
                var model = db.MenuLevel2.Find(id);
                db.MenuLevel2.Remove(model);
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
