using CustomerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Repository
{
    interface ICustomerRep
    {
        public List<Customer> getCustomerList(); 
    }
}
