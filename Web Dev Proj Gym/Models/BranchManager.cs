using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Dev_Proj_Gym.Models
{
    public class BranchManager
    {
        //BM = branch manager
        [ForeignKey("Branch Manager ID")]
        //[Required]
        public int ID { get; set; }
        public int BMUserName { get; set; }
        public string BMPassword { get; set; }
        public string BMName { get; set; }





    }
}
