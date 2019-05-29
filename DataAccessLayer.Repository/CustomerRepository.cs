using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : BaseRepository<SampleRepoPatternDBEntities>, ICustomerRepository
    {
        public IQueryable<CustomerModel> GetCustomers()
        {
            return DataContext.Customers.Select(model =>  new CustomerModel()
            {
                CustomerId=model.Id,
                CustomerAddress=model.Address,
                CustomerCountry=model.Country,
                CustomerEmail=model.Email,
                CustomerName=model.CustomerName,
                Phone_Number=model.PhoneNumber
            });
        }
        public CustomerModel GetCustomer(int Id)
        {
            return DataContext.Customers.Select(model => new CustomerModel()
            {
                CustomerId = model.Id,
                CustomerAddress = model.Address,
                CustomerCountry = model.Country,
                CustomerEmail = model.Email,
                CustomerName = model.CustomerName,
                Phone_Number = model.PhoneNumber
            }).FirstOrDefault(m=>m.CustomerId==Id);
        }
        public bool InsertCustomer(CustomerModel model)
        {
            var customer = new Customer()
            {
                Id = model.CustomerId,
                Address = model.CustomerAddress,
                Country = model.CustomerCountry,
                Email = model.CustomerEmail,
                CustomerName = model.CustomerName,
                PhoneNumber = model.Phone_Number
            };
            DataContext.Customers.Add(customer);
            return DataContext.SaveChanges() > 0;
        }
        public void UpdateCustomer(CustomerModel model)
        {
            var customer = DataContext.Customers.Find(model.CustomerId);
            if (customer!=null)
            {
                customer.Address = model.CustomerAddress;
                customer.Country = model.CustomerCountry;
                customer.Email = model.CustomerEmail;
                customer.PhoneNumber = model.Phone_Number;
                customer.CustomerName = model.CustomerName;
                DataContext.Entry(customer).State = EntityState.Modified;
                DataContext.SaveChanges();
            }
        }
        public void DeleteCustomer(int Id)
        {
            var customer = DataContext.Customers.Find(Id);
            DataContext.Customers.Remove(customer);
            DataContext.SaveChanges();
        }
        
    }
}
