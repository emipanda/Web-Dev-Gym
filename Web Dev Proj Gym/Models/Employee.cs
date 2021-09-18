using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Dev_Proj_Gym.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "ID")]

        public int StateID { get; set; }
        [Display(Name = "Name")]

        public string FullName { get; set; }
        [Display(Name = "Experience (in years)")]
        public int YearsOfExperience { get; set; }

        public int Age { get; set; }
        [Display(Name = "Teaches")]

        public List<Lesson> EmployeeLessonList{ get; set; }
        [Display(Name = "Works In")]

        public List<Branch> EmployeeBranchList { get; set; }
    }
}
