﻿// <auto-generated />
using System;
using DAB_Assignment_2_v2.Architecture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAB_Assignment_2_v2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211115131340_0.5_ezpz")]
    partial class _05_ezpz
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Activity", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcitivtyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Key", b =>
                {
                    b.Property<Guid>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomKey")
                        .HasColumnType("int");

                    b.HasKey("KeyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Key");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Member", b =>
                {
                    b.Property<Guid>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChairman")
                        .HasColumnType("bit");

                    b.Property<Guid>("KeyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Municipality", b =>
                {
                    b.Property<Guid>("MunicipalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MunicipalityId");

                    b.ToTable("Municipality");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Room", b =>
                {
                    b.Property<int>("RoomKey")
                        .HasColumnType("int");

                    b.Property<string>("RoomAdress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxMembers")
                        .HasColumnType("int");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("RoomAvailabilityEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("RoomAvailabilityStart")
                        .HasColumnType("time");

                    b.HasKey("RoomKey", "RoomAdress");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.RoomBooking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookedByMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomAdress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("RoomKey")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("BookedByMemberId");

                    b.HasIndex("RoomKey", "RoomAdress");

                    b.ToTable("RoomBooking");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.RoomProperties", b =>
                {
                    b.Property<Guid>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Chairs")
                        .HasColumnType("bit");

                    b.Property<bool>("CoffeeMachine")
                        .HasColumnType("bit");

                    b.Property<bool>("SoccerGoals")
                        .HasColumnType("bit");

                    b.Property<bool>("SoundSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("Tables")
                        .HasColumnType("bit");

                    b.Property<bool>("Toilet")
                        .HasColumnType("bit");

                    b.Property<bool>("Water")
                        .HasColumnType("bit");

                    b.Property<bool>("Whiteboard")
                        .HasColumnType("bit");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("PropertyId");

                    b.ToTable("RoomProperties");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Society", b =>
                {
                    b.Property<Guid>("SocietyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AcivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cvr")
                        .HasColumnType("int");

                    b.Property<Guid?>("MunicipalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MuniciplaityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SocietyId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Society");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.SocietyMemberRelations", b =>
                {
                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MemberId", "SocietyId");

                    b.HasIndex("SocietyId");

                    b.ToTable("SocietyMemberRelations");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Key", b =>
                {
                    b.HasOne("DAB_Assignment_2_v2.Models.Member", null)
                        .WithMany("Keys")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.RoomBooking", b =>
                {
                    b.HasOne("DAB_Assignment_2_v2.Models.Member", "BookedBy")
                        .WithMany()
                        .HasForeignKey("BookedByMemberId");

                    b.HasOne("DAB_Assignment_2_v2.Models.Room", null)
                        .WithMany("BookingIds")
                        .HasForeignKey("RoomKey", "RoomAdress");

                    b.Navigation("BookedBy");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Society", b =>
                {
                    b.HasOne("DAB_Assignment_2_v2.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("DAB_Assignment_2_v2.Models.Municipality", "Municipality")
                        .WithMany("Societies")
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Activity");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.SocietyMemberRelations", b =>
                {
                    b.HasOne("DAB_Assignment_2_v2.Models.Member", "Member")
                        .WithMany("SocietyMemberRelations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB_Assignment_2_v2.Models.Society", "Society")
                        .WithMany("SocietyMemberRelations")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Member", b =>
                {
                    b.Navigation("Keys");

                    b.Navigation("SocietyMemberRelations");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Municipality", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Room", b =>
                {
                    b.Navigation("BookingIds");
                });

            modelBuilder.Entity("DAB_Assignment_2_v2.Models.Society", b =>
                {
                    b.Navigation("SocietyMemberRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
