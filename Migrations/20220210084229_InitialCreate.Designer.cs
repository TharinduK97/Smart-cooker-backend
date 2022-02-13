﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart_Cookers.Data;

namespace Smart_Cookers.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220210084229_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Smart_Cookers.Models.Outlet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoorNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Outlets");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Smart_Cookers.Models.StaffMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OutletId");

                    b.HasIndex("RoleId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("Smart_Cookers.Models.StaffMember", b =>
                {
                    b.HasOne("Smart_Cookers.Models.Outlet", "Outlet")
                        .WithMany("StaffMembers")
                        .HasForeignKey("OutletId");

                    b.HasOne("Smart_Cookers.Models.Role", "Role")
                        .WithMany("StaffMembers")
                        .HasForeignKey("RoleId");

                    b.Navigation("Outlet");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Outlet", b =>
                {
                    b.Navigation("StaffMembers");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Role", b =>
                {
                    b.Navigation("StaffMembers");
                });
#pragma warning restore 612, 618
        }
    }
}