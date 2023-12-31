﻿// <auto-generated />
using AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(ThiDbContext))]
    partial class ThiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppData.SanPham", b =>
                {
                    b.Property<string>("MaSP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("NSX")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SLTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThuongHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSP");

                    b.ToTable("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
