using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoginDAO
    {
        private CMSDB db = null;
        public LoginDAO()
        {
            db = new CMSDB();
        }
        public int CheckLogin(string username, string passWord)
        {
            var result = db.Sys_User.SingleOrDefault(x => x.UserName == username);
            if (result == null)
                return 0;
            else if (result.IsDelete == false)
                return -1;
            else if (result.Enable == false)
                return -3;
            else
            {
                if (result.Password == passWord) return 1;
                else return -2;
            }
        }
        public Sys_User GetUserByUserName(string username)
        {
            return db.Sys_User.SingleOrDefault(x => x.UserName == username);
        }
    }
}
