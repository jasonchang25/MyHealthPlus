// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyHealthPlus.Persistence;

namespace MyHealthPlus.Migrations
{
    [DbContext(typeof(MyHealthPlusContext))]
    [Migration("20210623140837_initial-create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("MyHealthPlus.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AppointmentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AppointmentTypeId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            AppointmentDate = new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentTypeId = 1,
                            Comments = "",
                            SessionId = 3,
                            UserId = 3
                        },
                        new
                        {
                            AppointmentId = 2,
                            AppointmentDate = new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentTypeId = 2,
                            Comments = "",
                            SessionId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("MyHealthPlus.Entities.AppointmentType", b =>
                {
                    b.Property<int>("AppointmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentTypeId");

                    b.ToTable("AppointmentTypes");

                    b.HasData(
                        new
                        {
                            AppointmentTypeId = 1,
                            Type = "General Check Up"
                        },
                        new
                        {
                            AppointmentTypeId = 2,
                            Type = "Skin Cancer Check"
                        });
                });

            modelBuilder.Entity("MyHealthPlus.Entities.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("SessionId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            SessionId = 1,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 2,
                            EndTime = new TimeSpan(0, 11, 0, 0, 0),
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 3,
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            StartTime = new TimeSpan(0, 11, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 4,
                            EndTime = new TimeSpan(0, 13, 0, 0, 0),
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 5,
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            StartTime = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 6,
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            StartTime = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 7,
                            EndTime = new TimeSpan(0, 16, 0, 0, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            SessionId = 8,
                            EndTime = new TimeSpan(0, 17, 0, 0, 0),
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("MyHealthPlus.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DateOfBirth = new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@myhealthplus.com",
                            FirstName = "Bob",
                            LastName = "Boss",
                            Password = "Admin123",
                            PhoneNumber = "0400123456",
                            Sex = "Male",
                            UserTypeId = 1
                        },
                        new
                        {
                            UserId = 2,
                            DateOfBirth = new DateTime(1991, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "staff@myhealthplus.com",
                            FirstName = "Amy",
                            LastName = "Stake",
                            Password = "Staff123",
                            PhoneNumber = "0401234567",
                            Sex = "Female",
                            UserTypeId = 2
                        },
                        new
                        {
                            UserId = 3,
                            DateOfBirth = new DateTime(1997, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "client@gmail.com",
                            FirstName = "Hugh",
                            LastName = "Mungus",
                            Password = "Client123",
                            PhoneNumber = "0412345678",
                            Sex = "Male",
                            UserTypeId = 3
                        });
                });

            modelBuilder.Entity("MyHealthPlus.Entities.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            Type = "Admin"
                        },
                        new
                        {
                            UserTypeId = 2,
                            Type = "Staff"
                        },
                        new
                        {
                            UserTypeId = 3,
                            Type = "Client"
                        });
                });

            modelBuilder.Entity("MyHealthPlus.Entities.Appointment", b =>
                {
                    b.HasOne("MyHealthPlus.Entities.AppointmentType", "AppointmentType")
                        .WithMany()
                        .HasForeignKey("AppointmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyHealthPlus.Entities.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyHealthPlus.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentType");

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyHealthPlus.Entities.User", b =>
                {
                    b.HasOne("MyHealthPlus.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("MyHealthPlus.Entities.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
