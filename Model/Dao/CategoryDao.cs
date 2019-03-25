using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class CategoryDao
    {
        DBModel db = null;

        public CategoryDao()
        {
            db = new DBModel();
        }

        public IEnumerable<MenuLevel1> ListMenuLV1()
        {
            return db.MenuLevel1.Where(x => x.Status == true).ToList();
        }
    }
}
