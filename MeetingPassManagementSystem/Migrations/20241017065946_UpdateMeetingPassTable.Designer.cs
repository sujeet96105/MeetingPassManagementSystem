﻿// <auto-generated />
using System;
using MeetingPassManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetingPassManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241017065946_UpdateMeetingPassTable")]
    partial class UpdateMeetingPassTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeetingPassManagementSystem.Models.MeetingPass", b =>
                {
                    b.Property<int>("PassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassID"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MeetingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("MeetingTime")
                        .HasColumnType("time");

                    b.Property<string>("MeetingTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassCount")
                        .HasColumnType("int");

                    b.Property<string>("PassStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassID");

                    b.ToTable("MeetingPass");
                });
#pragma warning restore 612, 618
        }
    }
}
