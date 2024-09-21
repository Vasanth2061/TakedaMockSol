﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakedaMockData;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TakedaMockModels.Colleague", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTeamMemeber")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Colleagues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " Met during SPARK training. Both of us are Tamilains, so got along well",
                            ImageURL = " ",
                            IsTeamMemeber = true,
                            Name = "Jeevan Krishna"
                        });
                });

            modelBuilder.Entity("TakedaMockModels.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackGround")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobbies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tegnologies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnivEducation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BackGround = "A 2024 Graduate working in Deloitte for 2 months",
                            City = "Bangalore",
                            DateOfBirth = "21/02/2002",
                            Hobbies = "[\"Cricket\",\"Light Novels\"]",
                            Images = "[\"\",\"\"]",
                            Name = "Vasanth M",
                            PhoneNumber = "7975110608",
                            PinCode = "560057",
                            State = "Karnataka",
                            StreetAddress = "No 439, Vasanth Nilayam,3rd cross, Prakruti Badavane layout, Anchepalya",
                            Tegnologies = "[\"C#\",\"SQL Server\",\"HTML\",\"CSS\",\"JavaScript\"]",
                            UnivEducation = "Btech ECE, NITK"
                        });
                });

            modelBuilder.Entity("TakedaMockModels.TrainingActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingActivities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures",
                            EndDate = "30/7/2024",
                            Name = "SQL Server Foundation-Intermediate",
                            StartDate = "15/7/2024"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
