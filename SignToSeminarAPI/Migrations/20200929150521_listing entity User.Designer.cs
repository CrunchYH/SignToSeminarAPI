﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignToSeminarAPI.Context;

namespace SignToSeminarAPI.Migrations
{
    [DbContext(typeof(SignToSeminarDBContext))]
    [Migration("20200929150521_listing entity User")]
    partial class listingentityUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SignToSeminarAPI.Entities.Day", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("day")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.DaySeminar", b =>
                {
                    b.Property<int>("dayId")
                        .HasColumnType("int");

                    b.Property<int>("seminarId")
                        .HasColumnType("int");

                    b.HasKey("dayId", "seminarId");

                    b.HasIndex("seminarId");

                    b.ToTable("DaySeminars");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.Seminar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeminarOfSpeakerId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("SeminarOfSpeakerId");

                    b.ToTable("Seminars");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.Speaker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.UserSeminar", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("seminarId")
                        .HasColumnType("int");

                    b.HasKey("userId", "seminarId");

                    b.HasIndex("seminarId");

                    b.ToTable("UserSeminar");
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.DaySeminar", b =>
                {
                    b.HasOne("SignToSeminarAPI.Entities.Day", "day")
                        .WithMany("daySeminars")
                        .HasForeignKey("dayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignToSeminarAPI.Entities.Seminar", "seminar")
                        .WithMany("daySeminars")
                        .HasForeignKey("seminarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.Seminar", b =>
                {
                    b.HasOne("SignToSeminarAPI.Entities.Speaker", "speaker")
                        .WithMany("seminars")
                        .HasForeignKey("SeminarOfSpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignToSeminarAPI.Entities.UserSeminar", b =>
                {
                    b.HasOne("SignToSeminarAPI.Entities.Seminar", "seminar")
                        .WithMany("userSeminars")
                        .HasForeignKey("seminarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignToSeminarAPI.Entities.User", "user")
                        .WithMany("userSeminars")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
