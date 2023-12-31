﻿// <auto-generated />
using System;
using AppData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230615165956_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppData.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("MaSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhaSx")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThuongHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
