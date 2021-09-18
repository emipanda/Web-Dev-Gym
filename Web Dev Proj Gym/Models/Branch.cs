using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Dev_Proj_Gym.Models
{
    public class Branch
    {
        public int ID { get; set; }

        public string Address { get; set; }
        [Display(Name = "Number of Employees")]
        public  int NumOfEmployees { get; set; }
        [Display(Name = "Number of Employees")]
        public List<Lesson>  LessonList { get; set; }
        public List<Employee> EmployeeList { get; set; }
        //public BranchManager ThisBranchsManager { get; set; }
        public ICollection<BranchManager> Manager { get; set; }

    }
}
