﻿// <auto-generated />
using System;
using Api.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190610153449_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Course");
                });

            modelBuilder.Entity("Api.Entities.CourseStudent", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("StudentId");

                    b.Property<double?>("Score");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");
                });

            modelBuilder.Entity("Api.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Api.Entities.StudentAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("Api.Entities.ClassRoomCourse", b =>
                {
                    b.HasBaseType("Api.Entities.Course");

                    b.Property<string>("Address");

                    b.HasDiscriminator().HasValue("ClassRoomCourse");
                });

            modelBuilder.Entity("Api.Entities.OnlineCourse", b =>
                {
                    b.HasBaseType("Api.Entities.Course");

                    b.Property<string>("VideoUrl");

                    b.HasDiscriminator().HasValue("OnlineCourse");
                });

            modelBuilder.Entity("Api.Entities.CourseStudent", b =>
                {
                    b.HasOne("Api.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Entities.StudentAddress", b =>
                {
                    b.HasOne("Api.Entities.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("Api.Entities.StudentAddress", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
