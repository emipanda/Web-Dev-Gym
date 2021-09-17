using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Dev_Proj_Gym.Models
{
    public class CustomerTrainings// an event of a lesson - a lesson with a time and place
    {
        public int ID { get; set; }

        public Lesson ChosenLesson { get; set; }

        public DateTime Timing{ get; set; }

        public Branch TrainingLocation{ get; set; }

    }
}
