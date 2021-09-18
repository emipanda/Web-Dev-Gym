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
        public int StateID { get; set; }

        public string FullName { get; set; }

        public int YearsOfExperience { get; set; }

        public int Age { get; set; } 

        public List<Lesson> EmployeeLessonList{ get; set; }

        public List<Branch> EmployeeBranchList { get; set; }
    }
}
