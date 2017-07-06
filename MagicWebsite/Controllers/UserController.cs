using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using MagicWebsite.Models;
namespace MagicWebsite.Controllers
{
    /*This controller handles any function the User may do with their account.
    This Includes: Register, Login, Logout, Edit information, and delete an account;
    as well as the Home, About, and Contact pages*/
    public class UserController : Controller
    {
        private ISessionAccessor SessAcc;
        private IUserLogic UserLogic;
        private static Hash PassHash = new Hash();

        public UserController(IUserLogic logic, UserLogic userLogic, SessionAccessor Session)
        {
            UserLogic = logic;
            UserLogic = userLogic;
            SessAcc = Session;
        }
        //The first page a user will see
        public ActionResult HomeView()
        {
            return View();
        }
        //Creates a new user
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserVM model)
        {
            try
            {
                bool verify = UserLogic.RegisterUser(model.Email, PassHash.GetHash(model.Password), PassHash.GetHash(model.ConfirmPassword), model.FirstName, model.LastName, model.UserName, model.Role);
                if (verify == true)
                {
                    return RedirectToAction("LoginView");
                }
                else
                {
                    return RedirectToAction("Create");
                }

            }
            catch
            {
                return View();
            }
        }
        // The login view and logic
        public ActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginView(UserVM user)
        {
            try
            {
                DeckVM deck = new DeckVM();
                user = Mapper.Map<UserVM>(UserLogic.VerifyRole(user.Email, PassHash.GetHash(user.Password)));
                SessAcc.SetSessionAccessor(user, deck);
                if (user.Role != null)
                {
                    return RedirectToAction("HomeView");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //The Admin can see all users from this page and perform CRUD on a user going to another page
        public ActionResult ListOfUsersView()
        {
            List<UserVM> Model = Mapper.Map<List<UserVM>>(UserLogic.GetUserList());
            return View(Model);
        }
        public ActionResult IndivdualUserInfo(string email)
        {
            try
            {
                UserVM Model = Mapper.Map<UserVM>(UserLogic.GetUserDetail(email));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        //So a User or the Admin and Edit a users information
        public ActionResult EditUserInfo(string email)
        {
            try
            {
                UserVM Model = Mapper.Map<UserVM>(UserLogic.GetUserDetail(email));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditUserInfo(UserVM user)
        {
            try
            {
                if ((string)Session["Role"] != null)
                {
                    UserLogic.UpdateUserInfo(user.ID, user.Email, user.Password, user.FirstName, user.LastName, user.UserName, user.Role);
                    return View("HomeView");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        //A seprate view to reset a Password
        public ActionResult PasswordUpdate(string email)
        {
            UserVM model = Mapper.Map<UserVM>(UserLogic.GetUserDetail(email));
            model.Password = "";
            return View(model);
        }
        [HttpPost]
        public ActionResult PasswordUpdate(UserVM user)
        {
            try
            {
                if (PassHash.GetHash(user.ConfirmPassword) == PassHash.GetHash(user.Password))
                {
                    UserLogic.UpdateUserInfo(user.ID, user.Email, PassHash.GetHash(user.Password), user.FirstName, user.LastName, user.UserName, user.Role);

                    if ((string)Session["Role"] == "Admin")
                    {
                        return RedirectToAction("ListOfUsersView");
                    }
                    else if ((string)Session["Role"] == "Mod" || (string)Session["Role"] == "User")
                    {
                        return View("HomeView");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        //Delete a user
        public ActionResult DeleteUser(string email)
        {
            try
            {
                UserVM Model = Mapper.Map<UserVM>(UserLogic.GetUserDetail(email));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeleteUser(UserVM model)
        {
            try
            {
                UserLogic.DeleteUser(model.Email);
                return RedirectToAction("ListOfUsersView");
            }
            catch
            {
                return View();
            }
        }
        //About, Contact, and Logout methods
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Logout()
        {
            SessAcc.Clear();
            return RedirectToAction("HomeView", "User");
        }
    }
}
