﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vissoft.Infrastracture.Data;

#nullable disable

namespace Vissoft.Infrastracture.Migrations
{
    [DbContext(typeof(VissoftDbContext))]
    partial class VissoftDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Vissoft.Core.Entities.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("createdBy")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("grade_id")
                        .HasColumnType("int");

                    b.Property<string>("info")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("updatedBy")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("grade_id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Grade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Lesson", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("overview")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("thematic_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("thematic_id");

                    b.ToTable("Lesson", (string)null);
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Thematic", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.ToTable("Thematic", (string)null);
                });

            modelBuilder.Entity("Vissoft.Core.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .HasColumnType("longtext");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValueSql("true");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Course", b =>
                {
                    b.HasOne("Vissoft.Core.Entities.Grade", "Grade")
                        .WithMany("Courses")
                        .HasForeignKey("grade_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Lesson", b =>
                {
                    b.HasOne("Vissoft.Core.Entities.Thematic", "Thematic")
                        .WithMany("Lessons")
                        .HasForeignKey("thematic_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thematic");
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Thematic", b =>
                {
                    b.HasOne("Vissoft.Core.Entities.Course", "Course")
                        .WithMany("Thematics")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Course", b =>
                {
                    b.Navigation("Thematics");
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Grade", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Vissoft.Core.Entities.Thematic", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
