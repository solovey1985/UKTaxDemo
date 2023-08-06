﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.Infrastructure;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(TaxCalculatorDbContext))]
    partial class TaxCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxCalculator.Domain.Models.TaxBand", b =>
                {
                    b.Property<int>("LowerLimit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LowerLimit"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<int?>("UpperLimit")
                        .HasColumnType("int");

                    b.HasKey("LowerLimit");

                    b.ToTable("TaxBands");
                });
#pragma warning restore 612, 618
        }
    }
}
