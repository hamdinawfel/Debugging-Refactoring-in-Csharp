using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public class DataAccess
    {
        public static List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> output = new List<CustomerModel>();

            output.Add(new CustomerModel() { CustomerName = "acme", HourlyRate = 150 });
            output.Add(new CustomerModel() { CustomerName = "abc", HourlyRate = 125 });
            
            return output;


        }
    }
}
