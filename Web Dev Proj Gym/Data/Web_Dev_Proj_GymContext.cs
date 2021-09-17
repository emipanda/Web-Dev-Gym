using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_Dev_Proj_Gym.Models;

namespace Web_Dev_Proj_Gym.Data
{
    public class Web_Dev_Proj_GymContext : DbContext
    {
        public Web_Dev_Proj_GymContext (DbContextOptions<Web_Dev_Proj_GymContext> options)
            : base(options)
        {
        }

        public DbSet<Web_Dev_Proj_Gym.Models.Branch> Branch { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.CustomerTrainings> CustomerTrainings { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.Employee> Employee { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.Lesson> Lesson { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.TrainingProgram> TrainingProgram { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.Customer> Customer { get; set; }

        public DbSet<Web_Dev_Proj_Gym.Models.Admin> Admin { get; set; }
    }
}
