using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string PanNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
