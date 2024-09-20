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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasData(
               new Member 
               { 
                   Id=1, BackGround="A 2024 Graduate working in Deloitte for 2 months", DateOfBirth= new DateOnly(2002, 2,21 ),
                   Hobbies=new List<string> { "Cricket","Light Novels"},Name="Vasanth M", 
                   PhoneNumber="7975110608", UnivEducation="Btech ECE, NITK",
                   Tegnologies= new List<string> { "C#", "SQL Server", "HTML", "CSS", "JavaScript"},
                   StreetAddress="No 439, Vasanth Nilayam,3rd cross, Prakruti Badavane layout, Anchepalya",
                   City="Bangalore", State="Karnataka", PinCode="560057"
               }
            );

            modelBuilder.Entity<TrainingActivity>().HasData(
                new TrainingActivity 
                {
                    Id=1, Name="SQL Server Foundation-Intermediate",
                    Description="Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures",
                    EndDate=new DateOnly(2024,7,30),
                    StartDate=new DateOnly(2024,7,15)
                }
            );

            modelBuilder.Entity<Colleague>().HasData(
                new Colleague 
                {
                    Id=1, Name="Jeevan Krishna", ImageURL=" ",
                    Description=" Met during SPARK training. Both of us are Tamilains, so got along well",
                     IsTeamMemeber=true
                }
            );


        }
    }
}
