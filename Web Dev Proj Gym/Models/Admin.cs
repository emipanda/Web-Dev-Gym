using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Dev_Proj_Gym.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public int AdminUserName { get; set; }
        public string AdminPassword{ get; set; }
        public string AdminName { get; set; }
        public Branch ManagersBranch{ get; set; }


    }
}
