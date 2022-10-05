using Shivam.Models;
using Shivam.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shivam.Controllers
{
    public class HomeController : Controller
    {
        EntityDB con = new EntityDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Index()
        {
            var listindb = con.Emps.ToList();
            return View(listindb);
        }

        [HttpGet]
        public ActionResult AddData(int? EmpID)
        {
            Emp emp = new Emp();
            if (EmpID == null)
            {
                return View(emp);
            }
            else
            {
                var editindb = con.Emps.Find(EmpID);
                if (editindb == null)
                    return HttpNotFound();
                return PartialView("~/Views/Home/_Index.cshtml", editindb);
            }
        }

        [HttpPost]
        public ActionResult AddData(Emp emp)
        {
            if (emp == null)
                return HttpNotFound();
            if (emp.EmpID == 0)
            {
                con.Emps.Add(emp);
            }
            else
            {
                var empindb = con.Emps.Find(emp.EmpID);
                if (empindb == null)
                    return HttpNotFound();
                empindb.EmpName = emp.EmpName;
                empindb.EmpDesignation = emp.EmpDesignation;
                empindb.EmpAddress = emp.EmpAddress;
            }
            con.SaveChanges();
            return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditEmp(int? EmpID)
        {
            var editindb = con.Emps.Find(EmpID);
            {
                if (editindb == null)
                    return HttpNotFound();
            }
            return View(editindb);
        }

        [HttpPost]
        public ActionResult EditEmp(Emp emp)
        {
            if (emp == null)
                return HttpNotFound();
            var editindb = con.Emps.Find(emp.EmpID);
            if (editindb == null)
                return HttpNotFound();
            editindb.EmpName=emp.EmpName;
            editindb.EmpDesignation = emp.EmpDesignation;
            editindb.EmpAddress = emp.EmpAddress;
            con.SaveChanges();
            return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteEmp(int EmpID)
        {
            var deleteindb = con.Emps.Find(EmpID);
            if (deleteindb == null)
                return HttpNotFound();
            con.Emps.Remove(deleteindb);
            con.SaveChanges();
            return RedirectToAction("_Index", "Home");
        }
        public ActionResult AddUser()
        {
            var Userform = con.Users.ToList();
            return View(Userform);
        }

        [HttpGet]
        public ActionResult CreateForm()
        {
            return View();
        }
    }
}