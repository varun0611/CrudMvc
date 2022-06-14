using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models;
using MVCCRUD.Models.DAL;

namespace MVCCRUD.Controllers
{
    public class CrudController : Controller
    {
        private ICustRepo _custRepo;
        MvcCrudDBEntities1 ob = new MvcCrudDBEntities1();
        public CrudController()
        {
            this._custRepo = new CustRepo(new MvcCrudDBEntities1());
        }
        // GET: Crud
        public ActionResult Index()
        {
            return View(_custRepo.GetCustomers());
        }
        public ActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            _custRepo.InsertCustomer(c);
            _custRepo.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult GetProductById(int Custid)
        {
            return View();
        }
        public ActionResult Update(int id)
        {
            return View(_custRepo.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Update(Customer c)
        {
            _custRepo.UpdateCustomer(c);
            _custRepo.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _custRepo.DeleteCustomer(id);
            _custRepo.SaveChanges();
            return RedirectToAction("Index");
            //var res = ob.Customers.Where(x => x.Custid == id).First();
            //ob.Customers.Remove(res);
            //ob.SaveChanges();
            ////return View();
            //var list = ob.Customers.ToList();
            //return View("DisplayCustomers", list);
        }
    }
}