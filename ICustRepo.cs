using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCRUD.Models.DAL
{
    interface ICustRepo
    {
        IEnumerable<Customer> GetCustomers();
        void InsertCustomer(Customer cust);
        void DeleteCustomer(int Custid);
        Customer GetProductById(int Custid);
        void UpdateCustomer(Customer cust);
        void SaveChanges();
    }
}
