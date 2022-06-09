using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class CrudController : Controller
    {
        MvcCrudDBEntities1 ob = new MvcCrudDBEntities1();
        // GET: Crud
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Customer c)
        {
            if (ModelState.IsValid)
            {
                ob.Customers.Add(c);
                ob.SaveChanges();
                ViewBag.a = "Records inserted Successfully";
                return View();
            }
            else
            {
                return View();
            }

        }
        public ActionResult DisplayCustomers()
        {
            //var res = from t in ob.Customers
            //          select t;

            var re = ob.Customers.ToList();

            return View(re);
        }
        public ActionResult Delete(int id)
        {
            var res = ob.Customers.Where(x => x.Custid == id).First();
            ob.Customers.Remove(res);
            ob.SaveChanges();
            //return View();
            var list = ob.Customers.ToList();
            return View("DisplayCustomers", list);
        }
    }
}