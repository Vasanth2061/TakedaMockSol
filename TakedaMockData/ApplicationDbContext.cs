using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockModels;

namespace TakedaMockData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<TrainingActivity> TrainingActivities { get; set; }

        public DbSet<Colleague> Colleagues { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<PersonalImage> PersonalImages { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasData(
               new Member
               {
                   Id = 1,
                   BackGround = "A 2024 Graduate working in Deloitte for 2 months",
                   DateOfBirth = "21/02/2002",
                   Name = "Vasanth M",
                   PhoneNumber = "7975110608",
                   UnivEducation = "Btech ECE, NITK",
                   StreetAddress = "No 439, Vasanth Nilayam,3rd cross, Prakruti Badavane layout, Anchepalya",
                   City = "Bangalore",
                   State = "Karnataka",
                   PinCode = "560057"
               }
            );

            modelBuilder.Entity<TrainingActivity>().HasData(
                new TrainingActivity 
                {
                    Id=1, Name="SQL Server Foundation-Intermediate",
                    Description="Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures",
                    EndDate="30/7/2024",
                    StartDate="15/7/2024"
                }
            );

            modelBuilder.Entity<Colleague>().HasData(
                new Colleague 
                {
                    Id=1, ColleagueName="Jeevan Krishna", ImageURL=" ",
                    Description=" Met during SPARK training. Both of us are Tamilains, so got along well",
                    IsTeamMember=true
                }
            );

            modelBuilder.Entity<Technology>().HasData(
                new Technology { Id=1, Name="C#", Proficiency=4 },
                new Technology { Id = 2, Name = "SQL-Server", Proficiency = 4 }
            );

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1,Name="Cricket", Description="Self explanatory."}
            );

        }
    }
}
