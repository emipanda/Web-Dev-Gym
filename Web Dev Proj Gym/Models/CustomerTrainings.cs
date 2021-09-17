using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Dev_Proj_Gym.Models
{
    public class CustomerTrainings
    {
        public int ID { get; set; }

        public Lesson ChosenLesson { get; set; }

        public DateTime Timing{ get; set; }

        public Branch TrainingLocation{ get; set; }

    }
}
