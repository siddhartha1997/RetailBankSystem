﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RulesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RulesController));
       
        public static List<Account> accountList = new List<Account>
        {
            new Account{AccountId=101,Balance=1000},
            new Account{AccountId=102,Balance=400}
        };
        private object _log4;

        // GET: api/<RulesController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            _log4net.Info("Account List Obtained");
            return accountList;
        }

        // GET api/<RulesController>/5
        [HttpPost]
        [Route("evaluateMinBal")]
        public string evaluateMinBal([FromBody] Account value)
        {
            Account account = accountList.Find(a => a.AccountId == value.AccountId);
            _log4net.Info("Evaluating Minimum Balance");

            account.Balance = account.Balance - value.Balance;
            if (account.Balance < 500)
            {
                return "Deduct";
            }
            return "No deduction";
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
