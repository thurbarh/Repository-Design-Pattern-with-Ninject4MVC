using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryDesignDemo.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository repo;
        public CustomerController(ICustomerRepository _repo)
        {
            this.repo = _repo;
        }
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.customers = repo.GetCustomers().ToList();
            return View();
        }
        public JsonResult AddCustomer(CustomerModel model)
        {
            string res = "0";
            try {
                if (model.CustomerId > 0)
                {
                    repo.UpdateCustomer(model);
                }
                else
                {
                    repo.InsertCustomer(model);
                }
            }
            catch(Exception ex)
            {
                res = ex.InnerException != null ? 
                    ex.InnerException.Message : 
                    (string.IsNullOrEmpty(ex.Message) 
                    ? " An Error occured" 
                    : ex.Message);
            }
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustomer(int id)
        {
            var data = new CustomerModel();
            try
            {
                data = repo.GetCustomer(id);
            }
            catch
            {

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCustomer(int id)
        {
            var res = "0";
            try
            {
                repo.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                res = ex.InnerException != null ?
                    ex.InnerException.Message :
                    (string.IsNullOrEmpty(ex.Message)
                    ? " An Error occured"
                    : ex.Message);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}