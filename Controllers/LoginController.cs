using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Db;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext db;

        public LoginController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                StudentModel Data = db.StudentData.Where(i => i.Email == loginModel.EmailOrUsername && i.Password == loginModel.Password).FirstOrDefault();
                if (Data!=null)
                {
                    return RedirectToAction(nameof(Index), "Home", "LoginSuccessful");
                }
                else
                {
                    return RedirectToAction(nameof(Login),"Login","Login Failed : Username or Password is invalid");
                }
            }
            else
            {
                return RedirectToAction(nameof(Login), "Login", "Login Failed : ModelState=Invalid");
            }

        }
    }
}
