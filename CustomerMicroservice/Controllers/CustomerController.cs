using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomerMicroservice.Models;
using CustomerMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        Uri baseAddress = new Uri("https://localhost:44379/api");   //Port No.
        HttpClient client;
        readonly log4net.ILog _log4net;
        public CustomerController()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(CustomerController));
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        /*public static List<Customer> customerList = new List<Customer>
        {
            new Customer{id=1,Name="S B",DOB="05/09/1997",Address="ABC",PanNo="CGLBP1000",Email="sb@gmail.com",Password="123456"}
        };*/
        // GET: api/<CustomerController>
        /*[HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerList;
        }*/

        // GET api/<CustomerController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("getCustomerDetails/{id}")]
        public Customer getCustomerDetails(int id)
        {
            _log4net.Info("Customer Details Generated");
            var ob = new CustomerRep();
            var customerList = ob.getCustomerList();
            Customer customer = customerList.Find(u => u.id == id);
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("createCustomer")]
        public string createCustomer([FromBody] Customer customer)
        {
            _log4net.Info("Customer details and current and saving account is created");
            //Customer cust = new Customer();
            var ob = new CustomerRep();
            var customerList = ob.getCustomerList();
            customerList.Add(customer);
            string data = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Account/createAccount/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                /*string data1 =*/ return response.Content.ReadAsStringAsync().Result;
                /*cust = JsonConvert.DeserializeObject<Customer>(data1);
                return cust.ToString();*/
            }
            return "Account Creation Failed";
        }
        [HttpGet]
        [Route("getCustomerAccounts/{id}")]
        public string getCustomerAccounts(int id)
        {
            _log4net.Info("Customer Account is fetched");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Account/getCustomerDetails/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return "Link Failure";
        }
    }
}
