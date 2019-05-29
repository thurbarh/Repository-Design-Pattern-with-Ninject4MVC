using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CustomerModel
    {
        public int    CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Phone_Number { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerAddress { get; set; }
    }
}
