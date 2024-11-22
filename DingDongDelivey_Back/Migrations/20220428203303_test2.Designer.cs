﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DingDongDelivey_Back.Database;

namespace DingDongDelivey_Back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220428203303_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DingDongDelivey_Back.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("buyerId")
                        .HasColumnType("int");

                    b.Property<bool>("isDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("orderAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("orderItemid")
                        .HasColumnType("int");

                    b.Property<float>("orderPrice")
                        .HasColumnType("real");

                    b.Property<int>("orderQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeTillDelivery")
                        .HasColumnType("datetime2");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("orderItemid");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DingDongDelivey_Back.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DingDongDelivey_Back.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("deliveryS")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("hasOrder")
                        .HasColumnType("bit");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("orderId")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userT")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("orderId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userId = 1,
                            address = "Novi Sad",
                            dateOfBirth = new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            deliveryS = 3,
                            email = "godlike.jovan@gmail.com",
                            firstName = "Jovan",
                            hasOrder = false,
                            image = "",
                            isActive = true,
                            isDeleted = false,
                            lastName = "Miljkovic",
                            password = "jovan123",
                            userT = 0,
                            username = "AdminJovan"
                        });
                });

            modelBuilder.Entity("DingDongDelivey_Back.Models.Order", b =>
                {
                    b.HasOne("DingDongDelivey_Back.Models.Product", "orderItem")
                        .WithMany()
                        .HasForeignKey("orderItemid");

                    b.HasOne("DingDongDelivey_Back.Models.User", null)
                        .WithMany("orderList")
                        .HasForeignKey("userId");

                    b.Navigation("orderItem");
                });

            modelBuilder.Entity("DingDongDelivey_Back.Models.User", b =>
                {
                    b.HasOne("DingDongDelivey_Back.Models.Order", "order")
                        .WithMany()
                        .HasForeignKey("orderId");

                    b.Navigation("order");
                });

            modelBuilder.Entity("DingDongDelivey_Back.Models.User", b =>
                {
                    b.Navigation("orderList");
                });
#pragma warning restore 612, 618
        }
    }
}
