using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Dev_Proj_Gym.Models
{
    public class Branch
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public  int NumOfEmployees { get; set; }

        public List<Lesson>  LessonList { get; set; }

        public List<Employee> EmployeeList { get; set; }

    }
}
