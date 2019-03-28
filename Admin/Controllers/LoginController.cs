using Admin.Models;
using ClassLibrary;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        [OutputCache(Duration = 10000)]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
                var dao = new LoginDAO();
                var result = dao.CheckLogin(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetUserByUserName(model.UserName);
                    var userSession = new LoginModel();
                    userSession.UserName = model.UserName;
                    userSession.Password = model.Password;
                    userSession.RememberMe = model.RememberMe;
                    //var listCredentials = dao.GetListCredential(model.Email);
                    //Session.Add(CMS.Common.CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, user);
                    Session.Add
                        (CommonConstants.CHECK_LOGIN, userSession);
                    return View("/Admin/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");

                }
            //}
            return View();

        }
    }
}