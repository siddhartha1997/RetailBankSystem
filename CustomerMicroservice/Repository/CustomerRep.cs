using CustomerMicroservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMicroservice.Repository
{
    public class CustomerRep : ICustomerRep
    {
        public List<Customer> getCustomerList()
        {
            List<Customer> customerList = new List<Customer>
            {
                new Customer{id=1,Name="S B",DOB="05/09/1997",Address="ABC",PanNo="CGLBP1000",Email="sb@gmail.com",Password="123456"}
            };
            return customerList;
        }
    }
}
