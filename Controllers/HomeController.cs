using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Db;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentModel> Data = db.StudentData.ToList();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel studentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StudentData.Add(studentModel);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception er)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int ID)
        {
            try
            {
                StudentModel student = db.StudentData.Find(ID);
                if (student==null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Update(StudentModel studentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StudentData.Update(studentModel);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception er)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            try
            {
                StudentModel student = db.StudentData.Find(ID);
                if (student==null)
                {
                    return RedirectToAction(nameof(Index));
                }
                db.StudentData.Remove(student);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public string DeleteConfirmed(int ID)
        {
            try
            {
                StudentModel student = db.StudentData.Find(ID);
                if (student == null)
                {
                    return "Failed";
                }
                db.StudentData.Remove(student);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception er)
            {
                return "Failed";
            }
        }


    }
}
