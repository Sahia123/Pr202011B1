using CRUD_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_DBFirst.Controllers
{
    public class HomeController : Controller
    {
        test3Entities db = new test3Entities();
        // GET: Home
        public ActionResult Index()
        {
            List<Student> lst = db.Students.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
       Student std = db.Students.FirstOrDefault(i => i.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student std = db.Students.FirstOrDefault(i => i.Id == id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            db.Entry(std).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Student std = db.Students.FirstOrDefault(i => i.Id == id);
            return View(std);
        }
    }
}