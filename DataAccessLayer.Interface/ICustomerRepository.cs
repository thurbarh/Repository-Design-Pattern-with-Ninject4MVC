using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICustomerRepository
    {
        IQueryable<CustomerModel> GetCustomers();
        CustomerModel GetCustomer(int Id);
        bool InsertCustomer(CustomerModel model);
        void UpdateCustomer(CustomerModel model);
        void DeleteCustomer(int Id);
    }
}
