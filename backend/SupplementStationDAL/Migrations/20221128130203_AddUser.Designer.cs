﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplementStationDAL;

#nullable disable

namespace SupplementStationDAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221128130203_AddUser")]
    partial class AddUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplementStationDAL.Entities.ProductEntity", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productID"));

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("productID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            productID = -1,
                            image = "https://cdn.shopify.com/s/files/1/1525/5556/products/whey-matrix-quad-blend-whey-protein-complex-545871_1024x1024.jpg?v=1657561376",
                            productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris gravida elit vel tellus facilisis, dapibus.",
                            productName = "Protein"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}