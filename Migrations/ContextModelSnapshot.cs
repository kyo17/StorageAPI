﻿// <auto-generated />
using AzureStorage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzureStorage.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("AzureStorage.Models.Catalogo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("activa")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("edicion")
                        .HasColumnType("int");

                    b.Property<string>("foto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Catalogos");
                });
#pragma warning restore 612, 618
        }
    }
}
