using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Web_Dev_Proj_Gym.Models
{
    public class SuperAdmin
    {
        [Key]
        public string SMUserName { get; set; }

        public string SMpassword { get; set; }

    }
}
