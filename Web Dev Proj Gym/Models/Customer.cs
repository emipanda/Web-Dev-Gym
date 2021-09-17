using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Dev_Proj_Gym.Models
{
    public class Customer
    {
        [Key]
        public string UserName{ get; set; }
        public string Password { get; set; }
        public List<CustomerTrainings> MyTrainings { get; set; }
    }
}
