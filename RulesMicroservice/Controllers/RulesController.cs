using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RulesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RulesController));

        Uri baseAddress = new Uri("https://localhost:44379/api");   //Port No.
        HttpClient client;

      

        public RulesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
           
        }

        // GET: api/<RulesController>
    /*    [HttpGet]
        public IEnumerable<Account> Get()
        {
            _log4net.Info("Account List Obtained");
            return accountList;
        }*/

        // GET api/<RulesController>/5
        [HttpPost]
        [Route("evaluateMinBalCurrent")]
        public List<CurrentAccount> evaluateMinBal([FromBody] CurrentAccount value)
        {
            List<CurrentAccount> ls = new List<CurrentAccount>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Account/getCurrentAccountList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<CurrentAccount>>(data);
            }
            
            if (true)
            {
                return ls;
            }
        }




        [HttpPost]
        [Route("evaluateMinBalSavings")]
        public List<SavingsAccount> evaluateMinBal([FromBody] SavingsAccount value)
        {
            List<SavingsAccount> ls1 = new List<SavingsAccount>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Account/getSavingsAccountList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls1 = JsonConvert.DeserializeObject<List<SavingsAccount>>(data);
            }




            if (true)
            {
                return ls1;
            }

        }



        [HttpGet]
        [Route("getServiceCharges")]
        public int getServiceCharges()
        {
            _log4net.Info("Service Charges logged");
            return 100;
        }

    
    }
}
