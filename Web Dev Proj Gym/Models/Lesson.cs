using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Dev_Proj_Gym.Models
{
    public class Lesson
    {
        public int ID { get; set; }

        public  int LessonDuration { get; set; }

        public int CalorieBurn { get; set; }

        public int MaxParticipants { get; set; }

        public string LessonType { get; set; }

        public Employee LessonTrainer { get; set; }
    }
}
