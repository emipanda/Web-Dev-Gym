using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Dev_Proj_Gym.Models
{
    public class TrainingProgram
    {
        public int ID { get; set; }

        public int ProgramDuration { get; set; }

        public String ProgramPurpose { get; set; }
        //becoming ripped or gaining muscle mass

        public int WeightGoal { get; set; }

        public List<CustomerTrainings> ProgramsTrainingsList { get; set; }
    }
}
