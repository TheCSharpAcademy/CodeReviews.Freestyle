﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(FootballContext))]
    partial class FootballContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Data.Models.MatchData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwayTeam")
                        .HasColumnType("TEXT");

                    b.Property<double?>("AwayWin")
                        .HasColumnType("REAL");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Draw")
                        .HasColumnType("REAL");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("TEXT");

                    b.Property<double?>("HomeWin")
                        .HasColumnType("REAL");

                    b.Property<string>("League")
                        .HasColumnType("TEXT");

                    b.Property<double?>("OverFourGoals")
                        .HasColumnType("REAL");

                    b.Property<double?>("OverOneGoal")
                        .HasColumnType("REAL");

                    b.Property<double?>("OverThreeGoals")
                        .HasColumnType("REAL");

                    b.Property<double?>("OverTwoGoals")
                        .HasColumnType("REAL");

                    b.Property<double?>("UnderFourGoals")
                        .HasColumnType("REAL");

                    b.Property<double?>("UnderOneGoal")
                        .HasColumnType("REAL");

                    b.Property<double?>("UnderThreeGoals")
                        .HasColumnType("REAL");

                    b.Property<double?>("UnderTwoGoals")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("MatchData");
                });
#pragma warning restore 612, 618
        }
    }
}
