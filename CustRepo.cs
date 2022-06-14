using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models.DAL
{
    public class CustRepo : ICustRepo
    {
        private MvcCrudDBEntities1 _mvcCrudDBEntities1;
        public CustRepo(MvcCrudDBEntities1 mvcCrudDBEntities1)
        {
            this._mvcCrudDBEntities1 = mvcCrudDBEntities1;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _mvcCrudDBEntities1.Customers.ToList();
        }
        public void InsertCustomer(Customer cust)
        {
            _mvcCrudDBEntities1.Customers.Add(cust);
        }
        public void DeleteCustomer(int Custid)
        {
            Customer cid = _mvcCrudDBEntities1.Customers.Find(Custid);
            _mvcCrudDBEntities1.Customers.Remove(cid);
        }
        public Customer GetProductById(int Custid)
        {
            return _mvcCrudDBEntities1.Customers.Find(Custid);
        }
        public void UpdateCustomer(Customer cust)
        {
            _mvcCrudDBEntities1.Entry(cust).State = System.Data.Entity.EntityState.Modified;
        }
        public void SaveChanges()
        {
            _mvcCrudDBEntities1.SaveChanges();
        }
    }
}