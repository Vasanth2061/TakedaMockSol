﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakedaMockData;

#nullable disable

namespace TakedaMockDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240921100244_AddedSomeChanges")]
    partial class AddedSomeChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Colleagues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " Met during SPARK training. Both of us are Tamilains, so got along well",
                            ImageURL = " ",
                            IsTeamMemeber = true,
                            MemberId = 1,
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

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("TrainingActivities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learnt about DDL,DML queries, the types of locks, triggers, functions and stored procedures",
                            EndDate = new DateOnly(2024, 7, 30),
                            MemberId = 1,
                            Name = "SQL Server Foundation-Intermediate",
                            StartDate = new DateOnly(2024, 7, 15)
                        });
                });

            modelBuilder.Entity("TakedaMockModels.Colleague", b =>
                {
                    b.HasOne("TakedaMockModels.Member", "Member")
                        .WithMany("Colleagues")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TakedaMockModels.TrainingActivity", b =>
                {
                    b.HasOne("TakedaMockModels.Member", "Member")
                        .WithMany("TrainingActivities")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TakedaMockModels.Member", b =>
                {
                    b.Navigation("Colleagues");

                    b.Navigation("TrainingActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
