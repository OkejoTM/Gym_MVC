﻿// <auto-generated />
using System;
using GymWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymWeb.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymWeb.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Today im david goggins"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Today im still david goggins"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Today im the DAVID GOGGINGS"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
