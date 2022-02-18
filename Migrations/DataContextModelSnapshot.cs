﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart_Cookers.Data;

namespace Smart_Cookers.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Smart_Cookers.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DoorNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StaffMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OutletId");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Smart_Cookers.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Outlet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DoorNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Outlets");
                });

            modelBuilder.Entity("Smart_Cookers.Models.OutletProduct", b =>
                {
                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.HasKey("OutletId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OutletProducts");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("StaffMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("Products");
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

            modelBuilder.Entity("Smart_Cookers.Models.Address", b =>
                {
                    b.HasOne("Smart_Cookers.Models.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Order", b =>
                {
                    b.HasOne("Smart_Cookers.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Smart_Cookers.Models.Outlet", "Outlet")
                        .WithMany("Orders")
                        .HasForeignKey("OutletId");

                    b.HasOne("Smart_Cookers.Models.StaffMember", "StaffMember")
                        .WithMany("Orders")
                        .HasForeignKey("StaffMemberId");

                    b.Navigation("Customer");

                    b.Navigation("Outlet");

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("Smart_Cookers.Models.OrderProduct", b =>
                {
                    b.HasOne("Smart_Cookers.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Cookers.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Smart_Cookers.Models.OutletProduct", b =>
                {
                    b.HasOne("Smart_Cookers.Models.Outlet", "Outlet")
                        .WithMany("OutletProducts")
                        .HasForeignKey("OutletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Cookers.Models.Product", "Product")
                        .WithMany("OutletProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outlet");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Product", b =>
                {
                    b.HasOne("Smart_Cookers.Models.StaffMember", "StaffMember")
                        .WithMany("Products")
                        .HasForeignKey("StaffMemberId");

                    b.Navigation("StaffMember");
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

            modelBuilder.Entity("Smart_Cookers.Models.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Outlet", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("OutletProducts");

                    b.Navigation("StaffMembers");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("OutletProducts");
                });

            modelBuilder.Entity("Smart_Cookers.Models.Role", b =>
                {
                    b.Navigation("StaffMembers");
                });

            modelBuilder.Entity("Smart_Cookers.Models.StaffMember", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
